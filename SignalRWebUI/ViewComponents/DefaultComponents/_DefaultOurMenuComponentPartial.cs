﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.ProductDtos;
using SignalRWebUI.Dtos.SliderDtos;

namespace SignalRWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultOurMenuComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultOurMenuComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7218/api/Product");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            return View(values);
        }
    }
}