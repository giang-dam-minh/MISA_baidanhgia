using MISA.ApplicationCore.Interfaces;
using MISA.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Services
{
    public class TestService : BaseService<test>, ITestService
    {
        ITestRepository _testRepository;
        public TestService(ITestRepository testRepository) : base(testRepository)
        {
            _testRepository = testRepository;
        }
    }
}
