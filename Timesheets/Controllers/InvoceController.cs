using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.DDD;

namespace Timesheets.Controllers
{

    [Route("api/inv")]
    //[Route("[controller]")]
    [ApiController]
    public class InvoceController : Controller
    {
        private static readonly List<Customer> CustomerList = new List<Customer>() 
        {
            new Customer{id=1,Name="Quisque Ac Libero LLP"},
            new Customer{id=2,Name="Nulla Facilisi Foundation"},
            new Customer{id=3,Name="Eu Nibh Vulputate Company"},
            new Customer{id=4,Name="Enim Corp."},
        };
        private static readonly List<Contract> ContractList = new List<Contract>()
        {
            new Contract{id=1,Description="",Customer=CustomerList[0],StartDate=DateTime.Today,EndtDate=DateTime.Today,PricePerHour=50},
            new Contract{id=2,Description="",Customer=CustomerList[1],StartDate=DateTime.Today,EndtDate=DateTime.Today,PricePerHour=50},
            new Contract{id=3,Description="",Customer=CustomerList[2],StartDate=DateTime.Today,EndtDate=DateTime.Today,PricePerHour=50},
            new Contract{id=4,Description="",Customer=CustomerList[3],StartDate=DateTime.Today,EndtDate=DateTime.Today,PricePerHour=50},
        };


 
        private static readonly List<InvoiceDDD> InvoicesList  = new List<InvoiceDDD>()
        {
            new InvoiceDDD{Id=1,Contract=ContractList[0],DateFrom=DateTime.Today,DateTo=DateTime.Today},
            new InvoiceDDD{Id=2,Contract=ContractList[1],DateFrom=DateTime.Today,DateTo=DateTime.Today},
            new InvoiceDDD{Id=3,Contract=ContractList[2],DateFrom=DateTime.Today,DateTo=DateTime.Today},
            new InvoiceDDD{Id=4,Contract=ContractList[3],DateFrom=DateTime.Today,DateTo=DateTime.Today}
        };

        public static List<InvoiceDDD> InvoicesList1 => InvoicesList;

        //
        [HttpGet("Customers")]
        public IActionResult GetCustomers()
        {
            return Ok(CustomerList);
        }
        //
        [HttpGet("Contracts")]
        public IActionResult GetContracts()
        {

            return Ok(ContractList);
        }
        //
        [HttpGet("Invoices")]
        public IActionResult GetInvoice()
        {
            return Ok(InvoicesList);
        }


        //Применение DDD 
        [HttpGet("AcceptInvoce/{id}")]
        public IActionResult InvoiceAcc([FromRoute] int id)
        {
            try
            {
                InvoiceDDD InvoiceId = InvoicesList.Find(p => p.Id == id);
                if (InvoiceId is null == false)
                {
                    InvoiceId.InvoiceTrue(); //Изменение инвариантов, применение DDD
                    return Ok("Запись обновлена.");
                }
                else
                {
                    return Ok("Запись не найдена.");
                }
                
               
            }
            catch (Exception)
            {
                return Ok("ERR");
            }

        }

    }
}
