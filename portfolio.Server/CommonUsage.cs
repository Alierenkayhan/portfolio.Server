#region MongoDB
global using MongoDB.Driver;
global using MongoDB.Bson;
global using MongoDB.Bson.Serialization.Attributes;
global using Microsoft.Extensions.Options;
#endregion

#region Microsoft
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.AspNetCore.Authorization;
global using Newtonsoft.Json;
#endregion

#region System
global using System.Net;
global using System.Text;
global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
#endregion

#region Proje İçi
global using portfolio.Server.Data;
global using portfolio.Server.Middlewares;
global using portfolio.Server.Models;
global using portfolio.Server.Models.History;
global using portfolio.Server.Models.About;
global using portfolio.Server.Services.Concrete;
global using portfolio.Server.Services.Abstract;
global using portfolio.Server.Manager;
#endregion

#region Serilog
global using Serilog;
global using Serilog.Events;
global using Serilog.Core;
#endregion
