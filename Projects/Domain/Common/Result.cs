using System;
using System.Collections.Generic;
using System.Text;

namespace NUCA.Projects.Domain.Common
{
    public class Result
    {
        public bool IsSuccess { get; }
        public Error? Error { get; }
        public bool IsFailure => !IsSuccess;

        protected Result(bool isSuccess, Error? error)
        {
            if (isSuccess && error != null)
                throw new InvalidOperationException();
            if (!isSuccess && error == null)
                throw new InvalidOperationException();

            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Fail(Error? error)
        {
            return new Result(false, error);
        }

        public static Result<T> Fail<T>(Error? error)
        {
            return new Result<T>(default(T), false, error);
        }

        public static Result Ok()
        {
            return new Result(true, null);
        }

        public static Result<T> Ok<T>(T value)
        {
            return new Result<T>(value, true, null);
        }
    }

    public class Result<T> : Result
    {
        private readonly T _value;
        public T Value
        {
            get
            {
                if (!IsSuccess)
                    throw new InvalidOperationException();

                return _value;
            }
        }

        protected internal Result(T value, bool isSuccess, Error? error)
            : base(isSuccess, error)
        {
            _value = value;
        }
    }

    public enum Error
    {
        DatabaseError,
        ItemNotFound,
        ItemAlreadyExists
    }
}