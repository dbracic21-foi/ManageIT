﻿using DataAccessLayer.Models;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ClientRepo : Repository<Client>
    {
        public ClientRepo() : base(new ManageITModel())
        {

        }

        public IQueryable<ClientViewModel> GetClientView()
        {
            var query = from c in Entities
                        select new ClientViewModel
                        {
                            ID_Client = c.ID_client,
                            TypeName = c.ClientType.Title,
                            FirstName = c.FirstName,
                            LastName = c.LastName,
                            CompanyName = c.CompanyName,
                            IBAN = c.IBAN,
                            Email = c.Email,
                            Address = c.Client_Address,
                            Number = c.Number
                        };
            return query;
        }

        public IQueryable<ClientViewModel> SearchClients(string key)
        {
            var query = from c in Entities
                        where c.CompanyName.Contains(key) || c.FirstName.Contains(key) || c.LastName.Contains(key)
                        select new ClientViewModel
                        {
                            ID_Client = c.ID_client,
                            TypeName = c.ClientType.Title,
                            FirstName = c.FirstName,
                            LastName = c.LastName,
                            CompanyName = c.CompanyName,
                            IBAN = c.IBAN,
                            Email = c.Email,
                            Address = c.Client_Address,
                            Number = c.Number
                        };
            return query;
        }

        public void DeleteClient (int id)
        {
            var clientToDelete = Entities.FirstOrDefault(c => c.ID_client == id);
            if (clientToDelete != null)
            {
                Entities.Remove(clientToDelete);
                SaveChanges();
            }
        }
    }
}