using Ishopping.Domain.Entities;
using Ishopping.Infra.Data.EntityConfig;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Ishopping.Infra.Data.Contexto
{   
    public class IshoppingContext : DbContext
    {        
        public IshoppingContext()
            : base("IShoppingProject")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<AdminFinancialPlan> AdminFinancialPlan { get; set; }
        public DbSet<AdminImageGallery> AdminImageGallery { get; set; }
        public DbSet<AdminSlider> AdminSlider { get; set; }
        public DbSet<AdminSliderConfig> AdminSliderConfig { get; set; }
        public DbSet<AdminSocialNetWork> AdminSocialNetWork { get; set; }
        public DbSet<AdminTemplate> AdminTemplate { get; set; }
        public DbSet<AdminViewData> AdminViewData { get; set; }
        public DbSet<AdminViewItem> AdminViewItem { get; set; }
        public DbSet<AppView> AppView { get; set; }
        public DbSet<ComponentActivity> ComponentActivity { get; set; }
        public DbSet<ComponentActivityOption> ComponentActivityOption { get; set; }
        public DbSet<ComponentBrand> ComponentBrand { get; set; }
        public DbSet<ComponentBrandOption> ComponentBrandOption { get; set; }
        public DbSet<ComponentClient> ComponentClient { get; set; }
        public DbSet<ComponentClientOption> ComponentClientOption { get; set; }
        public DbSet<ComponentExtraLink> ComponentExtraLink { get; set; }
        public DbSet<ComponentExtraLinkOption> ComponentExtraLinkOption { get; set; }
        public DbSet<ComponentFaq> ComponentFaq { get; set; }
        public DbSet<ComponentFaqOption> ComponentFaqOption { get; set; }
        public DbSet<ComponentFeatures> ComponentFeatures { get; set; }
        public DbSet<ComponentFeaturesOption> ComponentFeaturesOption { get; set; }
        public DbSet<ComponentMenu> ComponentMenu { get; set; }
        public DbSet<ComponentMenuOption> ComponentMenuOption { get; set; }
        public DbSet<ComponentPanel> ComponentPanel { get; set; }
        public DbSet<ComponentPanelOption> ComponentPanelOption { get; set; }
        public DbSet<ComponentPortofolio> ComponentPortofolio { get; set; }
        public DbSet<ComponentPortofolioOption> ComponentPortofolioOption { get; set; }
        public DbSet<ComponentPost> ComponentPost { get; set; }
        public DbSet<ComponentPostOption> ComponentPostOption { get; set; }
        public DbSet<ComponentPresentation> ComponentPresentation { get; set; }
        public DbSet<ComponentPresentationOption> ComponentPresentationOption { get; set; }
        public DbSet<ComponentPricing> ComponentPricing { get; set; }
        public DbSet<ComponentPricingOption> ComponentPricingOption { get; set; }
        public DbSet<ComponentProject> ComponentProject { get; set; }
        public DbSet<ComponentProjectOption> ComponentProjectOption { get; set; }
        public DbSet<ComponentScope> ComponentScope { get; set; }
        public DbSet<ComponentScopeOption> ComponentScopeOption { get; set; }
        public DbSet<ComponentService> ComponentService { get; set; }       
        public DbSet<ComponentServiceOption> ComponentServiceOption { get; set; }
        public DbSet<ComponentSimpleProduct> ComponentSimpleProduct { get; set; }
        public DbSet<ComponentSimpleProductOption> ComponentSimpleProductOption { get; set; }
        public DbSet<ComponentSkill> ComponentSkill { get; set; }
        public DbSet<ComponentSkillOption> ComponentSkillOption { get; set; }
        public DbSet<ComponentSocialNetwork> ComponentSocialNetwork { get; set; }
        public DbSet<ComponentSummary> ComponentSummary { get; set; }
        public DbSet<ComponentSummaryOption> ComponentSummaryOption { get; set; }
        public DbSet<ComponentTeam> ComponentTeam { get; set; }
        public DbSet<ComponentTeamOption> ComponentTeamOption { get; set; }
        public DbSet<ComponentTeamSocialNetwork> ComponentTeamSocialNetwork { get; set; }
        public DbSet<ComponentThumbnail> ComponentThumbnail { get; set; }
        public DbSet<ConfigUserAppearance> ConfigUserAppearance { get; set; }      
        public DbSet<ConfigUserDisplay> ConfigUserDisplay { get; set; }
        public DbSet<ConfigUserMaintenance> ConfigUserMaintenance { get; set; }
        public DbSet<ConfigUserStyleClass> ConfigUserStyleClass { get; set; }
        public DbSet<ConfigUserStyleColor> ConfigUserStyleColor { get; set; }
        public DbSet<ConfigUserViewItem> ConfigUserViewItem { get; set; }     
        public DbSet<ConfigUserView> ConfigUserView { get; set; }
        public DbSet<ContentButton> ContentButton { get; set; }
        public DbSet<ContentButtonOption> ContentButtonOption { get; set; }
        public DbSet<ContentIcon> ContentIcon { get; set; }
        public DbSet<ContentList> ContentList { get; set; }
        public DbSet<ContentListOption> ContentListOption { get; set; }
        public DbSet<ContentSlider> ContentSlider { get; set; }
        public DbSet<ContentText> ContentText { get; set; }
        public DbSet<ContentTextOption> ContentTextOption { get; set; }
        public DbSet<ContentVideo> ContentVideo { get; set; }
        public DbSet<ECommerceProductCategory> ECommerceProductCategory { get; set; }
        public DbSet<ECommerceProductGroup> ECommerceProductGroup { get; set; }
        public DbSet<ECommerceProduct> ECommerceProduct { get; set; }
        public DbSet<ECommerceProductSold> ECommerceProductSold { get; set; }
        public DbSet<ECommerceShoppingList> ECommerceShoppingList { get; set; }   
        public DbSet<SupportError> SupportError { get; set; }
        public DbSet<SupportInfo> SupportInfo { get; set; }
        public DbSet<SupportNotification> SupportNotification { get; set; }
        public DbSet<SupportTransaction> SupportTransaction { get; set; }
        public DbSet<SupportTransactionStatus> SupportTransactionStatus { get; set; }    
        public DbSet<UserFinancialHistory> UserFinancialHistory { get; set; }
        public DbSet<UserFinancial> UserFinancial { get; set; }
        public DbSet<UserImageGallery> UserImageGallery { get; set; }
        public DbSet<UserMenuView> UserMenuView { get; set; }
        public DbSet<UserMenuViewItem> UserMenuViewItem { get; set; }
        public DbSet<UserMenu> UserMenu { get; set; }
        public DbSet<UserRegisterProfile> UserRegisterProfile { get; set; }
        public DbSet<UserRegisterStandard> UserRegisterStandard { get; set; }
        public DbSet<UserSerializeViewData> UserSerializeViewData { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(150));

            modelBuilder.Configurations.Add(new SupportTransactionStatusConfiguration());
            modelBuilder.Configurations.Add(new SupportTransactionConfiguration());

            modelBuilder.Configurations.Add(new AdminFinancialPlanConfiguration());
            modelBuilder.Configurations.Add(new AdminImageGalleryConfiguration());
            modelBuilder.Configurations.Add(new AdminSliderConfiguration());
            modelBuilder.Configurations.Add(new AdminSliderConfigConfiguration());
            modelBuilder.Configurations.Add(new AdminSocialNetWorkConfiguration());
            modelBuilder.Configurations.Add(new AdminTemplateConfiguration());
            modelBuilder.Configurations.Add(new AdminViewDataConfiguration());
            modelBuilder.Configurations.Add(new AdminViewItemConfiguration());
            modelBuilder.Configurations.Add(new ComponentActivityConfiguration());
            modelBuilder.Configurations.Add(new ComponentActivityOptionConfiguration());
            modelBuilder.Configurations.Add(new ComponentBrandConfiguration());
            modelBuilder.Configurations.Add(new ComponentBrandOptionConfiguration());
            modelBuilder.Configurations.Add(new ComponentClientConfiguration());
            modelBuilder.Configurations.Add(new ComponentClientOptionConfiguration());
            modelBuilder.Configurations.Add(new ComponentExtraLinkConfiguration());
            modelBuilder.Configurations.Add(new ComponentExtraLinkOptionConfiguration());
            modelBuilder.Configurations.Add(new ComponentFaqConfiguration());
            modelBuilder.Configurations.Add(new ComponentFaqOptionConfiguration());
            modelBuilder.Configurations.Add(new ComponentFeaturesConfiguration());
            modelBuilder.Configurations.Add(new ComponentFeaturesOptionConfiguration());
            modelBuilder.Configurations.Add(new ComponentMenuConfiguration());
            modelBuilder.Configurations.Add(new ComponentMenuOptionConfiguration());
            modelBuilder.Configurations.Add(new ComponentPanelConfiguration());
            modelBuilder.Configurations.Add(new ComponentPanelOptionConfiguration());
            modelBuilder.Configurations.Add(new ComponentPortofolioConfiguration());
            modelBuilder.Configurations.Add(new ComponentPortofolioOptionConfiguration());
            modelBuilder.Configurations.Add(new ComponentPostConfiguration());
            modelBuilder.Configurations.Add(new ComponentPostOptionConfiguration());
            modelBuilder.Configurations.Add(new ComponentPresentationConfiguration());
            modelBuilder.Configurations.Add(new ComponentPresentationOptionConfiguration());
            modelBuilder.Configurations.Add(new ComponentPricingConfiguration());
            modelBuilder.Configurations.Add(new ComponentPricingOptionConfiguration());
            modelBuilder.Configurations.Add(new ComponentProjectConfiguration());
            modelBuilder.Configurations.Add(new ComponentProjectOptionConfiguration());
            modelBuilder.Configurations.Add(new ComponentScopeConfiguration());
            modelBuilder.Configurations.Add(new ComponentScopeOptionConfiguration());
            modelBuilder.Configurations.Add(new ComponentServiceConfiguration());
            modelBuilder.Configurations.Add(new ComponentServiceOptionConfiguration());
            modelBuilder.Configurations.Add(new ComponentSimpleProductConfiguration());
            modelBuilder.Configurations.Add(new ComponentSimpleProductOptionConfiguration());
            modelBuilder.Configurations.Add(new ComponentSkillConfiguration());
            modelBuilder.Configurations.Add(new ComponentSkillOptionConfiguration());
            modelBuilder.Configurations.Add(new ComponentSocialNetworkConfiguration());
            modelBuilder.Configurations.Add(new ComponentSummaryConfiguration());
            modelBuilder.Configurations.Add(new ComponentSummaryOptionConfiguration());
            modelBuilder.Configurations.Add(new ComponentTeamConfiguration());
            modelBuilder.Configurations.Add(new ComponentTeamOptionConfiguration());
            modelBuilder.Configurations.Add(new ComponentTeamSocialNetworkConfiguration());
            modelBuilder.Configurations.Add(new ComponentThumbnailConfiguration());
            modelBuilder.Configurations.Add(new ConfigUserAppearanceConfiguration());           
            modelBuilder.Configurations.Add(new ConfigUserDisplayConfiguration());
            modelBuilder.Configurations.Add(new ConfigUserMaintenanceConfiguration());
            modelBuilder.Configurations.Add(new ConfigUserStyleClassConfiguration());
            modelBuilder.Configurations.Add(new ConfigUserStyleColorConfiguration());
            modelBuilder.Configurations.Add(new ConfigUserViewItemConfiguration());       
            modelBuilder.Configurations.Add(new ConfigUserViewConfiguration());
            modelBuilder.Configurations.Add(new ContentButtonConfiguration());
            modelBuilder.Configurations.Add(new ContentButtonOptionConfiguration());
            modelBuilder.Configurations.Add(new ContentIconConfiguration());
            modelBuilder.Configurations.Add(new ContentListConfiguration());
            modelBuilder.Configurations.Add(new ContentListOptionConfiguration());
            modelBuilder.Configurations.Add(new ContentSliderConfiguration());
            modelBuilder.Configurations.Add(new ContentTextConfiguration());
            modelBuilder.Configurations.Add(new ContentTextOptionConfiguration());
            modelBuilder.Configurations.Add(new ContentVideoConfiguration());
            modelBuilder.Configurations.Add(new ECommerceProductCategoryConfiguration());
            modelBuilder.Configurations.Add(new ECommerceProductGroupConfiguration());
            modelBuilder.Configurations.Add(new ECommerceProductConfiguration());
            modelBuilder.Configurations.Add(new ECommerceProductSoldConfiguration());
            modelBuilder.Configurations.Add(new ECommerceShoppingListConfiguration());
            modelBuilder.Configurations.Add(new AppViewConfiguration());
            modelBuilder.Configurations.Add(new SupportErrorConfiguration());
            modelBuilder.Configurations.Add(new SupportInfoConfiguration());
            modelBuilder.Configurations.Add(new SupportNotificationConfiguration());
            modelBuilder.Configurations.Add(new UserFinancialHistoryConfiguration());
            modelBuilder.Configurations.Add(new UserFinancialConfiguration());
            modelBuilder.Configurations.Add(new UserImageGalleryConfiguration());
            modelBuilder.Configurations.Add(new UserMenuViewConfiguration());
            modelBuilder.Configurations.Add(new UserMenuViewItemConfiguration());
            modelBuilder.Configurations.Add(new UserMenuConfiguration());
            modelBuilder.Configurations.Add(new UserRegisterProfileConfiguration());
            modelBuilder.Configurations.Add(new UserRegisterStandardConfiguration());
            modelBuilder.Configurations.Add(new UserSerializeViewDataConfiguration());
        }        
    }
}
