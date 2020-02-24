using amusinghoS.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using amusinghos;
using amusinghoS.EntityData.Model;

namespace amusinghos.xUnit
{
   public  class XunitTests
    {
        //arrange
       private UnitOfWork unit = new UnitOfWork(new amusinghoS.EntityData.amusinghoSDbContext());
        [Fact]
        public async void InsertArticle()
        {
          bool isNonQuery =   await unit.amusingArticleRepository.InsertAsync(new amusingArticle()
            {
                 Description = "文，我称这个节为「渡劫」，是一场对国家、民族、社会和我们每一个人的巨大考验。尽管目前防控态势依旧严峻，返程大军即将开拔，但随着后续各项措施逐项有力落实",
                  Image = "static/untitled-1.fw-copy.png",
                   Title = "有一种过节，叫做团结"
          }, isSaveChange: true);
            Assert.True(isNonQuery);
        }

    }
}
