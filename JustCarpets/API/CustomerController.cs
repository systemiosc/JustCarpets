using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustCarpets.Interfaces;
using JustCarpets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Pages.Internal.Account;
using Microsoft.AspNetCore.Mvc;

namespace JustCarpets.API
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class CustomerController : ControllerBase
    {
        private ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> GetCustomer(string macAddress)
        {
            var account = await _customerService.GetCustomerAccount(macAddress);
            if (account.Success)
            {
                return Ok(account.Results);
            }
            else
            {
                return BadRequest(account.ErrorMessage);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var response = await _customerService.GetCustomers();

            if (response.Success)
            {
                return Ok(response.Results);
            }
            else
            {
                return BadRequest(response.ErrorMessage);
            }
        }

        [HttpPut]
        public async Task<IActionResult> PatchMethod(CustomerDto model)
        {
            var response = await _customerService.UpdateCustomer(model);

            if (response.Results)
            {
                return Ok();
            }
            else
            {
                return BadRequest(response.ErrorMessage);
            }
        }
    }
}