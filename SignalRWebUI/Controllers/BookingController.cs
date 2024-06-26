﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.BookingDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class BookingController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public BookingController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;//yapıcı metot
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7298/api/Booking");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpGet]
		public IActionResult CreateBooking()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateBooking(CreateBookingDto createBookingDto)
		{
			createBookingDto.BookingDescription = "Rezervasyon Alındı";
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createBookingDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7298/api/Booking", stringContent);//sayfaya giderken string contenti de götürüyor
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> DeleteBooking(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7298/api/Booking/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> UpdateBooking(int id)
		{
			//updateCategoryDto.CategoryStatus = true;
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7298/api/Booking/{id}");//once güncellemek istediğimiz veriyi getiriyoruz
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateBookingDto>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> UpdateBooking(UpdateBookingDto updateBookingDto)
		{
			updateBookingDto.BookingDescription= "Rezervasyon Güncellendi";
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateBookingDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7298/api/Booking/", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> BookingStatusApproved(int id)
		{
			var client = _httpClientFactory.CreateClient();
		    await client.GetAsync($"https://localhost:7298/api/Booking/BookingStatusApproved/{id}");
		
			return RedirectToAction("Index");
		}
		public async Task<IActionResult> BookingStatusCancelled(int id)
		{
			var client = _httpClientFactory.CreateClient();
			await client.GetAsync($"https://localhost:7298/api/Booking/BookingStatusCancelled/{id}");

			return RedirectToAction("Index");
		}
	}
}
