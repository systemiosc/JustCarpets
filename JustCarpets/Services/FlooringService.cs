using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustCarpets.Data;
using JustCarpets.Data.Entities;
using JustCarpets.Interfaces;
using JustCarpets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace JustCarpets.Services
{
    public class FlooringService : IFlooringService
    {
        private JustCarpetDbContext _dbContext;
        private readonly ILogger _logger;

        public FlooringService(JustCarpetDbContext context, ILogger<FlooringService> logger)
        {
            _dbContext = context;
            _logger = logger;
           
        }

        public async Task<FlooringServiceResponse> GetFlooring(SearchParametersDto search = null)
        {

            

            FlooringServiceResponse response = new FlooringServiceResponse();
            try
            {
                var AllFlooring = await _dbContext.Carpets.ToListAsync();

                // filters 
                if (!search.SkipSearchParameters || search == null)
                {
                    //pets
                    AllFlooring = AllFlooring.Where(e => e.PetFriendly == search.Pets).ToList();

                    //style
                    AllFlooring = AllFlooring.Where(e => e.Style == search.Style).ToList();

                }

                response.Results = AllFlooring.Select(e => new FlooringDto()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    DurabilityFactor = e.DurabilityFactor,
                    PriceM2 = e.PriceM2,
                    Properties = e.Propertys.Select(r => r.BulletPoint).ToList(),
                    Images = e.Images.Select(i => new FlooringImageDto()
                    {
                        Id = i.Id,
                        AlternateText = i.AlternateText,
                        ImageType = i.ImageType,
                        ImageName = i.ImageName,
                        Link = "/Images/" + i.Link
                    }).ToList()
                }).ToList();

                response.Success = true;

            }
            catch (Exception e)
            {
                response.Success = false;
                response.FriendlyError = e.ToString();
                _logger.LogError(e, "Error at flooring service on GetFLooring");
            }

            return response;
        }

        public async Task<FlooringServiceResponse> GetById(int Id)
        {
            FlooringServiceResponse response = new FlooringServiceResponse();

            try
            {

                var flooring = await _dbContext.Carpets.Include(e => e.Propertys).Include(e => e.Images)
                    .Include(e => e.CarpetColourPallets).Include(e => e.Options).Where(e => e.Id == Id)
                    .SingleOrDefaultAsync();
                    
                flooring.Propertys.Add(new CarpetPropertyEntity(){BulletPoint = "Test property one"});
                flooring.Propertys.Add(new CarpetPropertyEntity() { BulletPoint = "Test property two" });

                response.Results.Add(new FlooringDto()
                {
                    Id = flooring.Id,
                    Name = flooring.Name,
                    Description = flooring.Description,
                    PetFriendly = flooring.PetFriendly,
                    PriceM2 = flooring.PriceM2,
                    Images = flooring.Images.Select(e => new FlooringImageDto(){Id = e.Id, AlternateText = e.AlternateText, ImageName = e.ImageName, ImageType = e.ImageType}).ToList(),
                  Properties = flooring.Propertys.Select(e => e.BulletPoint).ToList()
                });

                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Get Flooring Exception");
                response.Success = false;
                response.FriendlyError = ex.ToString();
            }

            return response;

        }

        private async Task<bool> AddDemoData()
        {
            try
            {

                List<CarpetPropertyEntity> props = new List<CarpetPropertyEntity>();
                List<CarpetColourPalletEntity> colours = new List<CarpetColourPalletEntity>();

                CarpetEntity carpet = new CarpetEntity()
                {
                    Name = "Empress Carpet",
                    Description =
                        "The Empress carpet is available in a wide range of bleach cleanable colours, making it suitable for all areas around the home excluding bathrooms. Action backed for added comfort underfoot, Empress Carpet carries a 15-year wear warranty and 20-year stain warranty.",
                    PetFriendly = false,
                    PriceM2 = Convert.ToDecimal(22.50),

                };


                _dbContext.Carpets.Add(carpet);
                await _dbContext.SaveChangesAsync();

                props.Add(new CarpetPropertyEntity()
                {
                    BulletPoint = "Bleach cleanable carpet",
                    CarpetId = carpet.Id
                });

                props.Add(new CarpetPropertyEntity()
                {
                    BulletPoint = "Suitable for all rooms excluding bathrooms",
                    CarpetId = carpet.Id
                });

                props.Add(new CarpetPropertyEntity()
                {
                    BulletPoint = "15 - year wear warranty",
                    CarpetId = carpet.Id
                });

                props.Add(new CarpetPropertyEntity()
                {
                    BulletPoint = "20 year stain warranty",
                    CarpetId = carpet.Id
                });

                props.Add(new CarpetPropertyEntity()
                {
                    BulletPoint = " 100 % polypropylene",
                    CarpetId = carpet.Id
                });

                carpet.Propertys = props;



                List<CarpetImageEntity> images = new List<CarpetImageEntity>();

                images.Add(new CarpetImageEntity()
                {
                    ImageType = CarpetImageType.MainImage,
                    ImageName = "Main Image",
                    Link = "default.png",
                    AlternateText = "Default Image",
                    CarpetId = carpet.Id
                    
                });

                carpet.Images = images;

                carpet.Options = new List<CarpetSizeOptionEntity>();

                carpet.Options.Add(new CarpetSizeOptionEntity()
                {
                    Width = 3,
                    Length = 4,
                    M2 = 20,
                    CarpetId = carpet.Id
                });

                carpet.Options.Add(new CarpetSizeOptionEntity()
                {
                    Width = 5,
                    Length = 4,
                    M2 = 35,
                    CarpetId = carpet.Id
                });

                carpet.Options.Add(new CarpetSizeOptionEntity()
                {
                    Width = 6,
                    Length = 4,
                    M2 = 45,
                    CarpetId = carpet.Id
                });

                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
