namespace PhotoShare.Client.Core
{
    using Commands;
    using Services;
    using System;
    using System.Linq;

    public class CommandDispatcher
    {


        public string DispatchCommand(string[] commandParameters)
        {
            string cmdName = commandParameters[0];
            commandParameters = commandParameters.Skip(1).ToArray();
            string result = string.Empty;
            TagService tagService = new TagService();
            UserService userService = new UserService();
            TownService townService = new TownService();
            AlbumService albumService = new AlbumService();
            PictureService pictureService = new PictureService();
            switch (cmdName)
            {
                case "Login":
                    LoginUserCommand loginUser = new LoginUserCommand(userService);
                    result = loginUser.Execute(commandParameters);
                    break;
                case "RegisterUser":
                    RegisterUserCommand registerUser = new RegisterUserCommand(userService);
                    result = registerUser.Execute(commandParameters);
                    break;
                case "Logout":
                    LogoutCommand logout = new LogoutCommand();
                    result = logout.Execute();
                    break;
                case "CreateAlbum":
                    CreateAlbumCommand createAlbum = new CreateAlbumCommand(albumService, userService,tagService);
                    result = createAlbum.Execute(commandParameters);
                    break;
                case "ShareAlbum":
                    ShareAlbumCommand shareAlbum = new ShareAlbumCommand(albumService, userService);
                    result = shareAlbum.Execute(commandParameters);
                    break;
                case "UploadPicture":
                    UploadPictureCommand uploadPicture = new UploadPictureCommand(albumService, pictureService);
                    result = uploadPicture.Execute(commandParameters);
                    break;
                case "AddTown":
                    AddTownCommand addTown = new AddTownCommand(townService);
                    result = addTown.Execute(commandParameters);
                    break;
                case "AddTag":
                    AddTagCommand addTag = new AddTagCommand(tagService);
                    result = addTag.Execute(commandParameters);
                    break;
                case "AddTagTo":
                    AddTagToCommand addTagTo = new AddTagToCommand(tagService,albumService);
                    result = addTagTo.Execute(commandParameters);
                    break;
                case "ModifyUser":
                    ModifyUserCommand modifyUser = new ModifyUserCommand(userService,townService);
                    result = modifyUser.Execute(commandParameters);
                    break;
                case "MakeFriends":
                    MakeFriendsCommand makeFriends = new MakeFriendsCommand(userService);
                    result = makeFriends.Execute(commandParameters);
                    break;
                case "DeleteUser":
                    DeleteUser deleteUser = new DeleteUser(userService);
                    result = deleteUser.Execute(commandParameters);
                    break;
                case "ListFriends":
                    PrintFriendsListCommand listFriends = new PrintFriendsListCommand(userService);
                    result = listFriends.Execute(commandParameters);
                    break;
                case "Exit":
                    ExitCommand exit= new ExitCommand();
                    result = exit.Execute();
                    break;
                default:
                    throw new NotImplementedException($"Command < {cmdName} > not valid!");
            }
            return result;
        }
    }
}
