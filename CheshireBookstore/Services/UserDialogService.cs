﻿using Bookstore.Lib.Entities;
using CheshireBookstore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheshireBookstore.Services
{
    internal class UserDialogService : IUserDialog
    {
        public bool Edit(Book book)
        {
            return false;
        }
    }
}