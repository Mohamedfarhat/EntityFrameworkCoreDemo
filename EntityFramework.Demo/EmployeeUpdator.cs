﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Demo
{
    internal class EmployeeUpdator : IEmployeeUpdator
    {
        private readonly EmployeeContext employeeContext;

        public EmployeeUpdator(EmployeeContext employeeContext)
        {
            this.employeeContext = employeeContext;
        }

        public void Update(int id, string firstName)
        {
            var query = "UPDATE Employee SET first_name = (@firstName) WHERE id=(@id)";
            var param = new[] {
                new SqlParameter("@id", id),
                new SqlParameter("@firstName", firstName)
        };

            employeeContext.Database.ExecuteSqlRaw(query, param);
        }
    }
}