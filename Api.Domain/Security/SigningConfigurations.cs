using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace Api.Domain.Security
{
    public class SigningConfigurations
    {
        public SecurityKey Key { get; set; } //armazena a chave de securança para gerar o token 

        public SigningCredentials SigningCredentials { get; set; } // assinatura da chave 

        public SigningConfigurations()
        {
            //cria uma chave do tamanho de 2048 bits 
            using (var provider = new RSACryptoServiceProvider(2048))
            {
                //exporta parametros da biblioteca using System.Security.Cryptography;

                Key = new RsaSecurityKey(provider.ExportParameters(true));
            }

            SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256Signature);
        }
    }
}
