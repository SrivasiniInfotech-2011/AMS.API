using AMS.API.Repositories;
using AMS.API.Repositories.Apartments;
using AMS.API.Repositories.Blocks;
using AMS.API.Repositories.Houses;
using AMS.API.Repositories.HouseOwners;
using AMS.API.Repositories.Tenants;
using AMS.API.Repositories.Users;
using AMS.API.Services.Commands;
using AMS.API.Services.Queries;
using AMS.Models.Entities;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using IdentityServer4.AccessTokenValidation;
using AMS.Models.Constants;
using Microsoft.AspNetCore.Mvc.Controllers;
using AMS.API.Areas.Billing.Repositories;
using AMS.API.Areas.Billing.Services.Queries;
using AMS.API.Areas.Billing.Services.Commands;

namespace AMS.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AMS.API", Version = "v1" });
                c.TagActionsBy(api =>
                {
                    if (api.ActionDescriptor is ControllerActionDescriptor actionDescriptor)
                    {
                        var group = actionDescriptor.ControllerTypeInfo.GetCustomAttributes(typeof(GroupTagAttribute), true)
                            .Cast<GroupTagAttribute>().FirstOrDefault();
                        var groupName = actionDescriptor.ControllerTypeInfo.GetCustomAttribute<AreaAttribute>() == null ? actionDescriptor.ControllerName : actionDescriptor.ControllerTypeInfo.GetCustomAttribute<AreaAttribute>().RouteValue;
                        return group != null
                            ? new List<string> { group.Name }
                            : new List<string> { groupName };
                    }

                    throw new NullReferenceException("Couldn't find the group name");
                });

            });
            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
             .AddIdentityServerAuthentication(options =>
             {
                 options.Authority = "https://localhost:43610/";
                 options.ApiName = Constants.ApiResource.DataEventRecordsApi;
                 options.ApiSecret = Constants.ApiResource.ApiResourceSecret;
             });
            services.AddSingleton<IDapperContext>(s => new DapperContext(Configuration.GetConnectionString("AMSConnectionString")));
            services.AddTransient<IApartmentRepository, ApartmentRepository>();
            services.AddTransient<IBlockRepository, BlockRepository>();
            services.AddTransient<IHouseRepository, HouseRepository>();
            services.AddTransient<ITenantRepository, TenantRepository>();
            services.AddTransient<IHouseOwnerRepository, HouseOwnerRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IBankRepository, BankRepository>(s=>new BankRepository(new DapperContext(Configuration.GetConnectionString("BMSConnectionString"))));
            services.AddTransient<ICompanyRepository, CompanyRepository>(s =>new CompanyRepository(new DapperContext(Configuration.GetConnectionString("BMSConnectionString"))));

            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
            services.AddTransient<IMediator, Mediator>();
            
            services.AddTransient<IRequestHandler<GetAllApartments.Query, List<Apartment>>, GetAllApartments.Handler>();
            //services.AddTransient<IRequestHandler<Services.Queries.GetBank.Query, Apartment>, Services.Queries.GetBank.Handler>();
            //services.AddTransient<IRequestHandler<Services.Queries.GetBank.Query, Apartment>, Services.Queries.GetBank.Handler>();
            //services.AddTransient<IRequestHandler<Services.Queries.GetBankByExpression.Query, Apartment>, Services.Queries.GetBankByExpression.Handler>();
            services.AddTransient<IRequestHandler<CreateBank.Command, Bank>, CreateBank.Handler>();
            services.AddTransient<IRequestHandler<DeActivateBank.Command>, DeActivateBank.Handler>();

            services.AddTransient<IRequestHandler<UpdateBank.Command>, UpdateBank.Handler>();

            services.AddTransient<IRequestHandler<GetAllApartments.Query, List<Apartment>>, GetAllApartments.Handler>();
            //services.AddTransient<IRequestHandler<Services.Queries.GetCompany.Query,Company>, Services.Queries.GetCompany.Handler>();
            //services.AddTransient<IRequestHandler<Services.Queries.GetCompany.Query, Company>, Services.Queries.GetCompany.Handler>();
            //services.AddTransient<IRequestHandler<Services.Queries.GetCompanyByExpression.Query, Company>, Services.Queries.GetCompanyByExpression.Handler>();
            services.AddTransient<IRequestHandler<CreateCompany.Command, Company>, CreateCompany.Handler>();
            services.AddTransient<IRequestHandler<DeActivateCompany.Command>, DeActivateCompany.Handler>();
            services.AddTransient<IRequestHandler<UpdateCompany.Command>, UpdateCompany.Handler>();

            //services.AddTransient<IRequestHandler<GetAllApartments.Query, List<Apartment>>, GetAllApartments.Handler>();
            //services.AddTransient<IRequestHandler<GetApartment.Query, Apartment>, GetApartment.Handler>();
            //services.AddTransient<IRequestHandler<GetApartment.Query, Apartment>, GetApartment.Handler>();
            //services.AddTransient<IRequestHandler<GetApartmentByExpression.Query, List<Apartment>>, GetApartmentByExpression.Handler>();
            //services.AddTransient<IRequestHandler<CreateApartment.Command, Apartment>, CreateApartment.Handler>();
            //services.AddTransient<IRequestHandler<DeActivateApartment.Command>, DeActivateApartment.Handler>();
            //services.AddTransient<IRequestHandler<UpdateApartment.Command>, UpdateApartment.Handler>();



            services.AddTransient<IRequestHandler<GetAllBlocks.Query, List<Block>>, GetAllBlocks.Handler>();
            services.AddTransient<IRequestHandler<GetBlock.Query, Block>, GetBlock.Handler>();
            services.AddTransient<IRequestHandler<GetBlock.Query, Block>, GetBlock.Handler>();
            services.AddTransient<IRequestHandler<GetBlockByExpression.Query, List<Block>>, GetBlockByExpression.Handler>();
            services.AddTransient<IRequestHandler<CreateBlock.Command, Block>, CreateBlock.Handler>();
            services.AddTransient<IRequestHandler<DeActivateBlock.Command>, DeActivateBlock.Handler>();
            services.AddTransient<IRequestHandler<UpdateBlock.Command>, UpdateBlock.Handler>();


            services.AddTransient<IRequestHandler<GetAllHouses.Query, List<House>>, GetAllHouses.Handler>();
            services.AddTransient<IRequestHandler<GetHouse.Query, House>, GetHouse.Handler>();
            services.AddTransient<IRequestHandler<GetHouse.Query, House>, GetHouse.Handler>();
            services.AddTransient<IRequestHandler<GetHouseByExpression.Query, List<House>>, GetHouseByExpression.Handler>();
            services.AddTransient<IRequestHandler<CreateHouse.Command, House>, CreateHouse.Handler>();
            services.AddTransient<IRequestHandler<DeActivateHouse.Command>, DeActivateHouse.Handler>();
            services.AddTransient<IRequestHandler<UpdateHouse.Command>, UpdateHouse.Handler>();

            services.AddTransient<IRequestHandler<GetAllHouseOwners.Query, List<HouseOwner>>, GetAllHouseOwners.Handler>();
            services.AddTransient<IRequestHandler<GetHouseOwner.Query, HouseOwner>, GetHouseOwner.Handler>();
            services.AddTransient<IRequestHandler<GetHouseOwner.Query, HouseOwner>, GetHouseOwner.Handler>();
            services.AddTransient<IRequestHandler<GetHouseOwnerByExpression.Query, HouseOwner>, GetHouseOwnerByExpression.Handler>();
            services.AddTransient<IRequestHandler<CreateHouseOwner.Command, HouseOwner>, CreateHouseOwner.Handler>();
            services.AddTransient<IRequestHandler<DeActivateHouseOwner.Command>, DeActivateHouseOwner.Handler>();
            services.AddTransient<IRequestHandler<UpdateHouseOwner.Command>, UpdateHouseOwner.Handler>();


            services.AddTransient<IRequestHandler<GetAllTenants.Query, List<Tenant>>, GetAllTenants.Handler>();
            services.AddTransient<IRequestHandler<GetTenant.Query, Tenant>, GetTenant.Handler>();
            services.AddTransient<IRequestHandler<GetTenant.Query, Tenant>, GetTenant.Handler>();
            services.AddTransient<IRequestHandler<GetTenantByExpression.Query, Tenant>, GetTenantByExpression.Handler>();
            services.AddTransient<IRequestHandler<CreateTenant.Command, Tenant>, CreateTenant.Handler>();
            services.AddTransient<IRequestHandler<DeActivateTenant.Command>, DeActivateTenant.Handler>();
            services.AddTransient<IRequestHandler<UpdateTenant.Command>, UpdateTenant.Handler>();

            services.AddTransient<IRequestHandler<GetAllUsers.Query, List<User>>, GetAllUsers.Handler>();
            services.AddTransient<IRequestHandler<GetUserByUserNameAndPassword.Query, User>, GetUserByUserNameAndPassword.Handler>();
            services.AddTransient<IRequestHandler<CreateUser.Command, User>, CreateUser.Handler>();
            services.AddTransient<IRequestHandler<DeActivateUser.Command>, DeActivateUser.Handler>();
            services.AddTransient<IRequestHandler<UpdateUser.Command>, UpdateUser.Handler>();


            services.AddTransient<IRequestHandler<Areas.Billing.Services.Queries.GetAllBanks.Query, List<Bank>>, Areas.Billing.Services.Queries.GetAllBanks.Handler>();
            services.AddTransient<IRequestHandler<Areas.Billing.Services.Queries.GetBank.Query, Bank>, Areas.Billing.Services.Queries.GetBank.Handler>();
            services.AddTransient<IRequestHandler<Areas.Billing.Services.Commands.CreateBank.Command, Bank>, Areas.Billing.Services.Commands.CreateBank.Handler>();
            services.AddTransient<IRequestHandler<Areas.Billing.Services.Commands.DeActivateBank.Command>, Areas.Billing.Services.Commands.DeActivateBank.Handler>();
            services.AddTransient<IRequestHandler<Areas.Billing.Services.Commands.UpdateBank.Command>, Areas.Billing.Services.Commands.UpdateBank.Handler>();

            services.AddTransient<IRequestHandler<Areas.Billing.Services.Queries.GetAllCompanys.Query, List<Company>>, Areas.Billing.Services.Queries.GetAllCompanys.Handler>();
            services.AddTransient<IRequestHandler<Areas.Billing.Services.Queries.GetCompany.Query, Company>, Areas.Billing.Services.Queries.GetCompany.Handler>();
            services.AddTransient<IRequestHandler<Areas.Billing.Services.Commands.CreateCompany.Command, Company>, Areas.Billing.Services.Commands.CreateCompany.Handler>();
            services.AddTransient<IRequestHandler<Areas.Billing.Services.Commands.DeActivateCompany.Command>, Areas.Billing.Services.Commands.DeActivateCompany.Handler>();
            services.AddTransient<IRequestHandler<Areas.Billing.Services.Commands.UpdateCompany.Command>, Areas.Billing.Services.Commands.UpdateCompany.Handler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AMS.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });          
        }
    }
}
