﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Data.Models;

namespace Backend.Repository
{
    public class PersonaRepository : GenericRepository<Persona>, IPersonaRepository
    {
        private ApiDbContext context;
        private ILogger logger;

        public PersonaRepository(ApiDbContext context, ILogger<PersonaRepository> logger)
            : base(context, logger)
        {
        }

    }
}
