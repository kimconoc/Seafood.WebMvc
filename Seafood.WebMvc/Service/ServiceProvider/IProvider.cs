using Domain.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceProvider
{
    public interface IProvider : IDisposable
    {
        Task<ResponseBase<TResult>> GetAsync<TResult>(string uri, string token = "");
        Task<ResponseBase<TResult>> PostAsync<TResult>(string uri, dynamic fromBody, string token = "");
    }
}
