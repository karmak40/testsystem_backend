﻿using System;
using System.Collections.Generic;
using System.Linq;
using testsystem.context;
using testsystem.Interfaces.Repositories;
using testsystem.Models.Entities;

namespace testsystem.Repositories
{
    public class TestRepository : ITestRepository
    {

        private readonly MyContext MyContext;

        public TestRepository(MyContext myContext)
        {
            this.MyContext = myContext;
        }

        public ICollection<Test> GetTests(int positionId)
        {
            try
            {
                return MyContext.Tests.Where(pos => pos.Position.Id == positionId).Select(x => x).ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public int AddTest(Test model)
        {
            try
            {
                MyContext.Tests.Add(model);
                MyContext.SaveChanges();
                var id = model.Id;

                return id;

            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public bool RemoveTest(int id)
        {
            try
            {
                MyContext.Tests.Remove(MyContext.Tests.Find(id));
                MyContext.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool UpdateTest(Test model)
        {
            try
            {
                MyContext.Tests.Update(model);
                MyContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                var message = e.Message;
                return false;
            }

        }

        public Test Get(int testId)
        {
            try
            {
                var test = MyContext.Tests.FirstOrDefault(x => x.Id == testId);
                return test;
            }
            catch (Exception e)
            {
                var message = e.Message;
                return null;
            }
        }
    }
}
