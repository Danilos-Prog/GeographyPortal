using GeographyPortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace GeographyPortal.Services
{
    public interface IAuth
    {
        public Task CreateAsync(InputModel input);
    }
}
