using System.Data;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace BackOffice.Utils
{
    public static class Function
    {
        public static Expression<Func<T, bool>> AndAlso<T>(
            this Expression<Func<T, bool>> expr1,
            Expression<Func<T, bool>> expr2
        )
        {
            var parameter = Expression.Parameter(typeof(T));

            var leftVisitor = new ReplaceExpressionVisitor(expr1.Parameters[0], parameter);
            var left = leftVisitor.Visit(expr1.Body);

            var rightVisitor = new ReplaceExpressionVisitor(expr2.Parameters[0], parameter);
            var right = rightVisitor.Visit(expr2.Body);

            return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(left, right), parameter);
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        private static List<T> ConvertDataTable<T>(DataTable dt)
        {
            string json = JsonConvert.SerializeObject(dt);
            return JsonConvert.DeserializeObject<List<T>>(json) ?? [];
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static string RSAEncryption(string strText)
        {
            var publicKey =
                "<RSAKeyValue><Modulus>cqndQeH+clUoOn+cKRB3K/sRtX6TOfqu2vjeLSPSc+SzpI52yOA4BedE7dp2tlA9A46pi0WP18HOCAoZXy4qHA2ri7DOnsKX8Mg1Vr2KPAMl3YFWqhk/S99+4a/dpKDwrnRNi5kv0i2mllN5x5ZcZ9E7Y1e8nm9FGdIJCxA+XiM=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
            var testData = Encoding.UTF8.GetBytes(strText);
            using var rsa = new RSACryptoServiceProvider(1024);
            try
            {
                rsa.FromXmlString(publicKey.ToString());
                var encryptedData = rsa.Encrypt(testData, true);
                var base64Encrypted = Convert.ToBase64String(encryptedData);
                return base64Encrypted;
            }
            finally
            {
                rsa.PersistKeyInCsp = false;
            }
        }

        public static string RSADecryption(string strText)
        {
            var privateKey =
                "<RSAKeyValue><Modulus>cqndQeH+clUoOn+cKRB3K/sRtX6TOfqu2vjeLSPSc+SzpI52yOA4BedE7dp2tlA9A46pi0WP18HOCAoZXy4qHA2ri7DOnsKX8Mg1Vr2KPAMl3YFWqhk/S99+4a/dpKDwrnRNi5kv0i2mllN5x5ZcZ9E7Y1e8nm9FGdIJCxA+XiM=</Modulus><Exponent>AQAB</Exponent><P>zuYlR922YFu/MakBNDKCHn83FkYMQCaFvcDoUX4TZ4R2Qjg+acUjXzScV41Ul/mWedBwlXcGQ/epoB4OsOQkxQ==</P><Q>jeAVdokpxC+pKhKTAGFEXq7Z4Sji6UUrhf3ARcfa4v7hQEMqTlcui7jp9/kCz25feCpmzCPjg1E26mkWRLU1xw==</Q><DP>YHvO8t6fx/vBA4WOvCq5p0MoC0kLOXc9cyncrPQgVGvfQi48XNLEFgfQyLttsZmA5LmhZvIkh9mczsB1lWQvCQ==</DP><DQ>RP81cPBD36VOH6fo1cZ3+ZQPYfEAaXG6OO+vEkCfssVBxn7jlDXR7SGAp5fyRe7nfwkf9Sd+/d4BVv7EVaXLAQ==</DQ><InverseQ>grNU3qASSC4QYF7X6BB+lxIP3rHbaN0zSeTJtt0jJMNHA48PDv6FrGMj6KPWK0pDDPxKrTdEXD5JixSc8iR+gg==</InverseQ><D>B6P4AV7cxKOWBafhMP9O4ZheSri/eLqSkjbJHzrm2CAiNFHl6ma+dO4/MpY/GNDp7+W+uHAPMLJSV0jM/gGmfpbRAP7WGOaRMToBNwxHV/dwVqnNzjAS6pd8TJGt8lF6AbQla3uSABbyG/YXb59BXKEivPDOuCoFbY+tQTb/Tek=</D></RSAKeyValue>";
            var testData = Encoding.UTF8.GetBytes(strText);
            using var rsa = new RSACryptoServiceProvider(1024);
            try
            {
                var base64Encrypted = strText;
                rsa.FromXmlString(privateKey);
                var resultBytes = Convert.FromBase64String(base64Encrypted);
                var decryptedBytes = rsa.Decrypt(resultBytes, true);
                var decryptedData = Encoding.UTF8.GetString(decryptedBytes);
                return decryptedData.ToString();
            }
            finally
            {
                rsa.PersistKeyInCsp = false;
            }
        }

        public static string ObjectToJsonString(object obj)
        {
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(obj);
            return JSONString;
        }

        public static string HMACSHA256(string text, string key)
        {
            Encoding encoding = Encoding.UTF8;
            Byte[] textBytes = encoding.GetBytes(text);
            Byte[] keyBytes = encoding.GetBytes(key);
            Byte[] hashBytes;
            using (HMACSHA256 hash = new HMACSHA256(keyBytes))
                hashBytes = hash.ComputeHash(textBytes);
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }

    public class ReplaceExpressionVisitor : ExpressionVisitor
    {
        private readonly Expression _oldValue;
        private readonly Expression _newValue;

        public ReplaceExpressionVisitor(Expression oldValue, Expression newValue)
        {
            _oldValue = oldValue;
            _newValue = newValue;
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            return node == _oldValue ? _newValue : base.VisitParameter(node);
        }
    }
}
