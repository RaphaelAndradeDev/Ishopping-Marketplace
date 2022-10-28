using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using Ishopping.Domain.Communs;
using System;

namespace Ishopping.Domain.Entities
{
    public class ComponentTeamSocialNetwork : _SocialNetwork
    {
        public Guid Id { get; private set; }
        public string Link { get; private set; }

        // Relacionamento
        public Guid ComponentTeamId { get; private set; }
        public virtual ComponentTeam ComponentTeam { get; private set; }

        // Ctor
        protected ComponentTeamSocialNetwork() { }

        public ComponentTeamSocialNetwork(Guid componentTeamId, string link, string rede)
        {
            Validate(link, rede);

            this.ComponentTeamId = componentTeamId;
            this.Link = link;
            this.Rede = rede;           
        }

        // Methods
        public void Change(string link, string rede)
        {
            Validate(link, rede);
               
            this.Link = link;
            this.Rede = rede;
        }

        public void AddAdminClass(string classe1, string classe2, string classe3, string classe4)
        {
            this.Classe1 = classe1;
            this.Classe2 = classe2;
            this.Classe3 = classe3;
            this.Classe4 = classe4;
        }

        private void Validate(string link, string rede)
        {
            AssertionConcern.AssertArgumentNotEmpty(link, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(link, 128, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(rede, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(rede, 32, Errors.MaxLength);
        }
    }
}
