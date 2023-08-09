using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InquiryService.Data;
using InquiryService.Models;

namespace InquiryService.Services
{
    public class InquiryService
    {
        private readonly InquiryDbContext _context;

        public InquiryService(InquiryDbContext context)
        {
            _context = context;
        }

        public async Task<List<Inquiry>> GetInquiriesAsync()
        {
            return await _context.Inquiries.OrderByDescending(p => p.Id).ToListAsync();
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
