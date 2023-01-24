using EDSystems.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDSystems.Domain;
using Microsoft.EntityFrameworkCore;
using EDSystems.Domain.Entities;
using EDSystems.Application.Interfaces;
using EDSystems.Persistence.Services;
using CleanArchitecture.Infrastructure.Persistence.Interceptors;
using MediatR;

namespace EDSystems.Tests.Common;

public class BranchContextFactory
{
    public static Guid UserAid = Guid.NewGuid();
    public static Guid UserBid = Guid.NewGuid();

    public static Guid NoteIdForDelete = Guid.NewGuid();
    public static Guid NoteIdForUpdate = Guid.NewGuid();
    private static readonly IDateTimeService _dateTimeService;
    private static readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;
    private static readonly IMediator _mediator;
    
    public static EDSystemsDbContext Create()
    {
        var options = new DbContextOptionsBuilder<EDSystemsDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        var context = new EDSystemsDbContext(options, _dateTimeService, _auditableEntitySaveChangesInterceptor, _mediator);
        context.Database.EnsureCreated();
        context.Branch.AddRange(
            new Branch
            {
                Id=4,
                Name= "New Branch",
                Country = "New Country",
                City = "New City",
                Address= "New Addres",
                Email= "newemail@gmail.com",
                Phone= "1331409a",
                CreatedBy="administrator@gmail.com",
                 
                ModifiedBy="administrator@gmail.com"
            },
            new Branch
            {
                Id = 5,
                Name = "New Branch",
                Country = "New Country",
                City = "New City",
                Address = "New Addres",
                Email = "newemail@gmail.com",
                Phone = "1331409a",
                CreatedBy = "administrator@gmail.com",
                
                ModifiedBy = "administrator@gmail.com"
            },
            new Branch
            {
                Id = 6,
                Name = "New Branch",
                Country = "New Country",
                City = "New City",
                Address = "New Addres",
                Email = "newemail@gmail.com",
                Phone = "1331409a",
                CreatedBy = "administrator@gmail.com",
                
                ModifiedBy = "administrator@gmail.com"
            },
            new Branch
            {
                Id = 7,
                Name = "New Branch",
                Country = "New Country",
                City = "New City",
                Address = "New Addres",
                Email = "newemail@gmail.com",
                Phone = "1331409a",
                CreatedBy = "administrator@gmail.com",
                 
                ModifiedBy = "administrator@gmail.com"
            }
        );
        context.SaveChanges();
        return context;
    }

    public static void Destroy(EDSystemsDbContext context)
    {
        context.Database.EnsureDeleted();
        context.Dispose();
    }
}
