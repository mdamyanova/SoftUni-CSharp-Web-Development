namespace List_Processing.Core
{
    using System;
    using System.Linq;
    using Contracts;
    using Helpers;
    using Models;

    public class Engine : IEngine
    {
        //private CommandExecutor executor;

        private readonly ICommandInterpreter interpreter;
        private readonly Data data = new Data();
        private readonly Logger logger;

        public Engine(Logger logger, ICommandInterpreter interpreter)
        {
            this.IsRunning = true;

            this.logger = logger;
            this.interpreter = interpreter;

        }

        public bool IsRunning { get; set; }

        public void Run()
        {
            this.SeedData();

            while (this.IsRunning)
            {
                var output = Utils.AppendData(this.data.DataParams);

                this.logger.Write(output);

                var commandInput = this.logger.Read();

                try
                {
                    var command = this.interpreter.ParseCommand(commandInput);
                    command.Execute(this.data);

                    this.IsRunning = !this.data.EndReceived;
                }
                catch (Exception e)
                {
                    this.logger.Write(e.Message);
                }
            }
        }

        private void SeedData()
        {
            var dataInput = this.logger.Read();

            this.data.DataParams.AddRange(dataInput.Split().ToList());

            //var output = Utils.AppendData(data.DataParams);
            //this.logger.Write(output);
        }
    }
}