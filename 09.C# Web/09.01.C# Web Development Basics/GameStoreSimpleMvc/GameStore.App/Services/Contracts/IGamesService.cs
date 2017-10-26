namespace GameStore.App.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using GameStore.App.Data.Models;
    using Models.Games;

    public interface IGamesService
    {
        void Create(
            string title,
            string description,
            string thumbnailUrl,
            decimal price,
            double size,
            string videoId,
            DateTime releaseDate);

        void Update(
            int id,
            string title,
            string description,
            string thumbnailUrl,
            decimal price,
            double size,
            string videoId,
            DateTime releaseDate);

        void Delete(int id);

        Game GetById(int id);

        IEnumerable<GameListingAdminModel> All();
    }
}