using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InquiryService.Data;
using InquiryService.Models;
using Newtonsoft.Json;
using System.Net.Http;
using Faker;

namespace InquiryService.Services
{
    public class InquiryService
    {
        private readonly InquiryDbContext _context;
        private readonly HttpClient _httpClient;

        public InquiryService(InquiryDbContext context, HttpClient httpClient)
        {
            _context = context;
            _httpClient = httpClient;
        }

        public async Task<List<Inquiry>> GetInquiriesAsync()
        {
            var inquiries =  await _context.Inquiries.OrderByDescending(p => p.Id).ToListAsync();

            if (inquiries.Count == 0)
            {
                var response = await _httpClient.GetAsync("https://localhost:7143/api/Property");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var properties = JsonConvert.DeserializeObject<List<Property>>(content);
                    var sampleInquiries = new List<Inquiry>();

                    foreach (var p in properties)
                    {
                        var fakeName = Name.FullName();
                        var fakeEmail = Internet.Email();
                        var fakeMessage = Lorem.Sentence();

                        sampleInquiries.Add(new Inquiry
                        {
                            PropertyID = p.Id,
                            Name = fakeName,
                            Email = fakeEmail,
                            Date = DateTime.Now,
                            Message = fakeMessage
                        });
                    }

                    await _context.Inquiries.AddRangeAsync(sampleInquiries);
                    await _context.SaveChangesAsync();

                    inquiries = await _context.Inquiries.OrderByDescending(p => p.Id).ToListAsync();
                }                              
            }

            return inquiries;
        }

        public async Task<Inquiry> GetInquiryByIdAsync(int id)
        {
            return await _context.Inquiries.FindAsync(id);
        }

        public async Task CreateInquiryAsync(Inquiry inquiry)
        {
            _context.Inquiries.Add(inquiry);
            await _context.SaveChangesAsync();
        }
    }
}
