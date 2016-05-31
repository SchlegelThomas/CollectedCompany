using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using AutoMapper;

namespace CollectedCompany.Models.Shared
{
    public class Set: AbstractBaseAutoMapEntity<SetJsonModel>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public String GathererSetId { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string GathererCode { get; set; }

        public string OldCode { get; set; }

        public string MagicCardsInfoCode { get; set; }

        public DateTime ReleaseDate { get; set; }

        public Color BorderColor { get; set; }

        public String Type { get; set; }

        public String Block { get; set; }

        public virtual List<Card> Cards { get; set; }

        public override void CreateMaps()
        {
            Mapper.CreateMap<SetJsonModel, Set>()
                .ForMember(x => x.ReleaseDate, y => y.MapFrom(j => DateTime.Parse(j.ReleaseDate)))
                .ForMember(x => x.Cards, y => y.MapFrom(j => Mapper.Map<List<CardJsonModel>, List<Card>>(j.Cards)))
                .ForMember(x => x.GathererSetId, y => y.MapFrom(j => j.Id.ToString()))
                .ForMember(x => x.Id, y => y.MapFrom(j => Guid.NewGuid()));
        }
    }

    public class Card: AbstractBaseAutoMapEntity<CardJsonModel>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CardId { get; set; }

        public String Id { get; set; }

        public String Layout { get; set; }

        public String Name { get; set; }

        public String Names { get; set; }

        public String ManaCost { get; set; }

        public int ConvertedManaCost { get; set; }

        public List<Color> Colors { get; set; }

        public String Type { get; set; }

        public String SuperTypes { get; set; }

        public String Types { get; set; }

        public String SubTypes { get; set; }

        public String Rarity { get; set; }

        public String Text { get; set; }

        public String Flavor { get; set; }

        public String Artist { get; set; }

        public String Number { get; set; }

        public String Power { get; set; }

        public String Toughness { get; set; }

        public String Loyalty { get; set; }

        public String MultiverseId { get; set; }

        public String Variations { get; set; }

        public String ImageName { get; set; }

        public String Watermark { get; set; }

        public Color Border { get; set; }

        public Boolean Timeshifted { get; set; }

        public DateTime ReleaseDate { get; set; }

        public Decimal OurPrice { get; set; }

        public int QuantitySelling { get; set; }

        public int QuantityBuying { get; set; }

        [ForeignKey("Set")]
        public Guid SetId { get; set; }
        public virtual Set Set { get; set; }

        public int Mint { get; set; }
        public int SlightPlay { get; set; }
        public int ModeratePlay { get; set; }
        public int HeavyPlay { get; set; }


        public override void CreateMaps()
        {
            Mapper.CreateMap<CardJsonModel, Card>()
                .ForMember(x => x.ReleaseDate, y => y.MapFrom(j => DateTime.Now))
                .ForMember(x => x.Names, y => y.MapFrom(j => j.Names != null ? String.Join(",", j.Names): String.Empty))
                .ForMember(x => x.Variations, y => y.MapFrom(j => j.Variations != null ? String.Join(",", j.Variations) : String.Empty))
                .ForMember(x => x.Types, y => y.MapFrom(j => j.Types != null ? String.Join(",", j.Types) : String.Empty))
                .ForMember(x => x.SubTypes, y => y.MapFrom(j => j.SubTypes != null ? String.Join(",", j.SubTypes) : String.Empty))
                .ForMember(x => x.SuperTypes, y => y.MapFrom(j => j.SuperTypes != null ? String.Join(",", j.SuperTypes) : String.Empty));

        }
    }

    public class SetJsonModel
    {
        
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string GathererCode { get; set; }

        public string OldCode { get; set; }

        public string MagicCardsInfoCode { get; set; }

        public String ReleaseDate { get; set; }

        public Color BorderColor { get; set; }

        public String Type { get; set; }

        public String Block { get; set; }

        public virtual List<CardJsonModel> Cards { get; set; }
    }

    public class CardJsonModel
    {
        
        public String Id { get; set; }

        public String Layout { get; set; }

        public String Name { get; set; }

        public String[] Names { get; set; }

        public String ManaCost { get; set; }

        public int ConvertedManaCost { get; set; }

        public List<Color> Colors { get; set; }

        public String Type { get; set; }

        public String[] SuperTypes { get; set; }

        public String[] Types { get; set; }

        public String[] SubTypes { get; set; }

        public String Rarity { get; set; }

        public String Text { get; set; }

        public String Flavor { get; set; }

        public String Artist { get; set; }

        public String Number { get; set; }

        public String Power { get; set; }

        public String Toughness { get; set; }

        public String Loyalty { get; set; }

        public String MultiverseId { get; set; }

        public String[] Variations { get; set; }

        public String ImageName { get; set; }

        public String Watermark { get; set; }

        public Color Border { get; set; }

        public Boolean Timeshifted { get; set; }

        public String ReleaseDate { get; set; }

        public Decimal OurPrice { get; set; }

        public int QuantitySelling { get; set; }

        public int QuantityBuying { get; set; }
    }
}