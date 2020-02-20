using amusinghoS.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace amusinghos.xUnit
{
    public class DESTests
    {
        [Fact]
        public void EncryptOrDecrypt()
        {
            //arrange
            string serverCoonection = "Server=39.104.53.29; uid = zaranet; pwd = 123456; database = amusinghoS;";
            var miwen = DESEncryptHelper.Encrypt(serverCoonection, "12345678");

            string connection = DESEncryptHelper.Decrypt(
                   miwen
               , "12345678");
            //Act
            var result = DESEncryptHelper.Decrypt("BX+aN6+yUyRBOnwI/LJqs9ASfV9PCSaVeizUy8YKbumoFfQNzLZIhkEMDL5YSrETlyUXAlnJIfFuHGaexoXXUw+71cjSW630", "12345678");

            //Assert
            Assert.Equal(serverCoonection,result);
        }
    }
}
