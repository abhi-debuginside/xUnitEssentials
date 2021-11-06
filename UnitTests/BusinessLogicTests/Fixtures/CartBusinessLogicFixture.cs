using System;
using xUnit_Essentials.BusinessLogics;

namespace UnitTests.BusinessLogicTests.Fixtures
{
    public class CartBusinessLogicFixture : IDisposable
    {
        /// <summary>
        /// Create an instance of CartBusinessLogic class
        /// </summary>
        /// <returns></returns>
        public ICartBusinessLogic ContructCartBusinessLogicInstance()
        {
            return new CartBusinessLogic();
        }

        public void Dispose()
        {
            // add dispose code here
        }
    }
}
