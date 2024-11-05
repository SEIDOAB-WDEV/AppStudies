using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Models;
using Models.DTO;
using Microsoft.EntityFrameworkCore;
using Services;
using AppStudies.Pages;
using Azure.Core;
using Newtonsoft.Json;

namespace AppStudies.Pages
{
    //Demonstrate how to use the model to present a list of objects
    public class ReadWebApiModel : PageModel
    {
        private IMusicService _service;
        private ILogger<ReadWebApiModel> _logger = null;

        //public member becomes part of the Model in the Razor page
        public List<IAlbum> Albums { get; set; } = new List<IAlbum>();


        //Will execute on a Get request
        public async Task<IActionResult> OnGet()
        {
            var response = await _service.ReadAlbumsAsync(null, true, true, null, 0, 10);
            Albums = response.PageItems;
            return Page();
        }

        //Inject services just like in WebApi
        public ReadWebApiModel(IMusicService service, ILogger<ReadWebApiModel> logger)
        {
            _logger = logger;
            _service = service;
        }
    }
}
