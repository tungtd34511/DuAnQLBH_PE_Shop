using App.Data.Context;
using App.Data.Entities;
using App.Data.Repositories.Base;
using App.Data.Ultilities.Catalog.Orders;
using App.Data.Ultilities.Catalog.Products;
using App.Data.Ultilities.Common;
using App.Data.Ultilities.Enums;
using App.Data.Ultilities.PagingModels;
using App.Data.Ultilities.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repositories.Orders
{
    public class OrderRepositories : BaseRepositories<Order>, IOrderRepositories
    {
        private readonly QLBH_Context _context;
        public OrderRepositories(QLBH_Context context) : base(context)
        {
            _context = context;
        }
        public async Task<PagedResult<OderInPagingVm>> GetPagingOrder(GetPagingOrderRequest request)
        {
            //            Không sắp xếp
            //Theo tên khách hàng(A - Z)
            //Theo tên khách hàng(A-Z)
            //Theo người tạo(A - Z)
            //Theo người tạo(A - Z)
            //Theo Trạng Thái(Confirm - Canceled)
            //Theo Trạng Thái(Canceled - Confirm)
            //Theo ngày tạo(cũ - mới)
            //Theo ngày tạo(mới - cũ)
            //Tổng tiền(Tăng dần)
            //Tổng tiền(Giảm dần)
            try
            {
                int totalRow = 0;
                //1. Select join
                var query = from o in _context.Orders
                            join u in _context.UserDetails on o.UserCreatedId equals u.UserId into urs
                            from us in urs.DefaultIfEmpty()
                            orderby o.Id descending
                            select new { o, us };
                //2. filter
                if (!String.IsNullOrEmpty(request.Keyword))
                {
                    query = query.Where(c => c.o.Id.ToString() == request.Keyword || c.o.ShipName.ToLower().Contains(request.Keyword.ToLower()) || c.us.Name.ToLower().Contains(request.Keyword.ToLower()));
                }
                if (!request.Unhide)
                {
                    query = query.Where(c => c.o.Status != OrderStatus.Canceled);
                }
                //
                switch (request.Orderby)
                {
                    case 0:
                        break;
                    case 1:
                        query = query.OrderBy(c => c.o.ShipName);
                        break;
                    case 2:
                        query = query.OrderByDescending(c => c.o.ShipName);
                        break;
                    case 3:
                        query = query.OrderBy(c => c.us.Name);
                        break;
                    case 4:
                        query = query.OrderByDescending(c => c.us.Name);
                        break;
                    case 5:
                        query = query.OrderBy(c => c.o.Status);
                        break;
                    case 6:
                        query = query.OrderByDescending(c => c.o.Status);
                        break;
                    case 7:
                        query = query.OrderBy(c => c.o.Created);
                        break;
                    case 8:
                        query = query.OrderByDescending(c => c.o.Created);
                        break;
                    case 9:
                        query = query.OrderBy(c => c.o.Total);
                        break;
                    case 10:
                        query = query.OrderByDescending(c => c.o.Total);
                        break;
                }
                //3.Paging
                totalRow = await query.CountAsync();
                var data = query.Skip((request.PageIndex - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .Select(x => new OderInPagingVm()
                    {
                        Created = x.o.Created,
                        CustomerName = x.o.ShipName,
                        Id = x.o.Id,
                        Status = x.o.Status,
                        IsShipping = x.o.IsShipping,
                        Total = x.o.Total,
                        UserName = x.us.Name
                    }).ToList();
                //4. Select 

                var pagedResult = new PagedResult<OderInPagingVm>()
                {
                    TotalRecords = totalRow,
                    PageSize = request.PageSize,
                    PageIndex = request.PageIndex,
                    Items = data
                };
                return pagedResult;
            }
            catch
            {
                return new() { PageSize = 20, Items = new(), PageIndex = 1, TotalRecords = 0 };
            }
        }
        public async Task<OrderVm> GetOrderVmById(int id)
        {
            var order = await Entities.FindAsync(id);
            if (order == null)
            {
                return new();
            }

            var orderVm = new OrderVm()
            {
                Created = order.Created,
                ShipAddress = order.ShipAddress,
                ShipEmail = order.ShipEmail,
                ShipName = order.ShipName,
                ShipPhoneNumber = order.ShipPhoneNumber,
                Status = order.Status,
                IsShipping = order.IsShipping,
                CustomerId = order.CustomerId,
                Description = order.Description,
                Id = order.Id,
                Total = order.Total,
                UserCreatedId = order.UserCreatedId,
                UserName = order.ShipName
            };
            orderVm.Products = await (from p in _context.ProductInOrders
                                      join pv in _context.ProductVariations on p.ProductVariationId equals pv.Id
                                      join pd in _context.ProductDetails on pv.ProductId equals pd.ProductId
                                      join cl in _context.Colors on pv.ColorId equals cl.Id
                                      join s in _context.Sizes on pv.SizeId equals s.Id
                                      where p.OrderId == order.Id
                                      select new ProductInOrderVm()
                                      {
                                          Name = pd.Name + " " + cl.Name + " (" + s.Id + ")",
                                          Price = p.Price,
                                          Quantity = p.Quantity,

                                      }).ToListAsync();
            orderVm.Histories = await (from oh in _context.OrderHistories
                                       where oh.OderId == order.Id
                                       select new OrderHistoryVm()
                                       {
                                           Status = oh.Status,
                                           Details = oh.Details,
                                           Edited = oh.Edited,
                                           EditorName = oh.EditorName,
                                           OderName = oh.OderName
                                       }).ToListAsync();
            return orderVm;
        }
        public async Task<ThongKeViewModel> GetThongKe(GetThongKeRequest request)
        {
            try
            {

                var orders = Entities.Where(c => c.Created.Date > request.Started.Date && c.Created.Date <= request.Ended.Date);
                var query1 = orders.Where(c => c.Status == OrderStatus.Success);
                var revenues = new List<decimal>();
                for (DateTime i = request.Started.Date.AddDays(1); i <= request.Ended.Date; i = i.AddDays(1))
                {
                    revenues.Add(query1.Where(c => c.Created.Date == i).Select(c => c.Total).Sum());
                }
                var LowStocks = await (from pv in _context.ProductVariations
                                       join c in _context.Colors on pv.ColorId equals c.Id
                                       join s in _context.Sizes on pv.SizeId equals s.Id
                                       join pd in _context.ProductDetails on pv.ProductId equals pd.ProductId
                                       where pv.Stock < 20
                                       select new ProductVariationVm()
                                       {
                                           SizeId = s.Id,
                                           Stock = pv.Stock,
                                           ColorName = c.Name,
                                           ProductName = pd.Name,
                                           SizeName = s.Name,ColorId=c.Id,Id=pv.Id,ProductId=pv.ProductId,
                                           IsDeleted = pv.IsDeleted,
                                           Discount = 0
                                       }).ToListAsync();
                var TopFive = await _context.ProductInOrders.Where(c => orders.Select(d => d.Id).Contains(c.OrderId)).GroupBy(c => _context.ProductVariations.First(e => e.Id == c.ProductVariationId).ProductId).Select(g => new TopFiveVm() { Name = _context.ProductDetails.First(c => c.ProductId == g.Key).Name, Count = g.Select(c=>c.Quantity).Sum() }).ToListAsync();

                var thongke = new ThongKeViewModel()
                {
                    Revenues = revenues,
                    LowStocks = LowStocks,
                    TotalOrderShippings = await orders.Where(c => c.Status == OrderStatus.Shipping).CountAsync(),
                    TotalOrderSuccesss = await query1.CountAsync(),
                    TopFive = TopFive,
                    TotalOrderCanceleds = await orders.Where(c => c.Status == OrderStatus.Canceled).CountAsync(),
                    TotalOrderConfirms = await orders.Where(c => c.Status == OrderStatus.Confirmed).CountAsync(),
                    TotalOrders = await orders.CountAsync()
                };

                return thongke;
            }
            catch
            {
                return new ThongKeViewModel();
            }
        }
    }
}
