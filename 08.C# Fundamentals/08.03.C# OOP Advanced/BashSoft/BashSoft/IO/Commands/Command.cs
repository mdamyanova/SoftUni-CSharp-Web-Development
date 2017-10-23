using System;
using BashSoft.Contracts;
using BashSoft.Exceptions;

namespace BashSoft.IO.Commands
{
    using BashSoft.Attributes;

    public abstract class Command : IExecutable
    {
        private string input;
        private string[] data;

        [Inject]
        private IContentComparer judge;

        [Inject]
        private IDatabase repository;

        [Inject]
        private IDirectoryManager inputOutputManager;

        protected Command(string input, string[] data)
        {
            this.Input = input;
            this.Data = data;
        }

        public string Input
        {
            get { return this.input; }
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }

                this.input = value;
            }
        }

        public string[] Data
        {
            get { return this.data; }
            protected set
            {
                if (value == null || value.Length == 0)
                {
                    throw new NullReferenceException();
                }

                this.data = value;
            }
        }

        protected IContentComparer Judge
        {
            get { return this.judge; }
        }

        protected IDatabase Repository

        {
            get { return this.repository; }
        }

        protected IDirectoryManager InputOutputManager
        {
            get { return this.inputOutputManager; }
        }

        public abstract void Execute();
    }
}