using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flower.Areas.Dtos;

namespace Flower.DAL.Interfaces
{
    public interface IViewOrderService
{
    Task<List<ViewOrderDto>> GetUserOrdersAsync(int userId);
}

}