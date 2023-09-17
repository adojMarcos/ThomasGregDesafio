﻿namespace Cadastro.Core.Repositories.Command.Base
{
    public interface ICommandRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}