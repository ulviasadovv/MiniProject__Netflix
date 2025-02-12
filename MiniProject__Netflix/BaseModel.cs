﻿namespace MiniProject__Netflix
{
    internal class BaseModel
    {
        protected static int _id = 1;
        public int Id { get; private set; }

        protected BaseModel()
        {
            Id = _id++;
        }
    }
}
