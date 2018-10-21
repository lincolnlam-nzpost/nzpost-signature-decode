using System;
using System.Collections.Generic;
using System.Drawing;

namespace nzpost_signature_decode
{
    class Program
    {
        static void Main(string[] args)
        {
            String parcelTrackSignature = "/xdIF0cXRxdGF0YXRRhFGkMbQx5BIj4kPCg6MDU0MzgwQCpFJkgkUB9VG1gZXxNlD2YObQlxB3IGdwN6AHsAfQB//3//f/+A/4D/f/99/30AewB1AnQCbAZhDFwOVBNIGkMePSIzKi8uKzEkNyE6IDwePx5BHkEeQh5DHkMgRCNEI0QpQzBBMEE5PkU6RjpSNWAwYjBsK3cmeSV+IIYciBqMGZAWkRWTFZQUlBSUFJMVkhWRFo4XiBqFG3wfdSJzI2wnZStlK14vWTJZMlY0VDVUNVM2UzdTN1M3VTdVN1c3WzdcN2A2ZzVrNHAzfzKEMYkwkC6ULZcsmyqdKp4poCigKKAonyefJ58nnCeZKJkokyuNLo0viDKDNII1fzd7OXo5eDt2PHY8dj12PXY+dj54Pno+fD6APoQ9hj2NPJY8mjylPKw7rju2Ors5vDnCOMc3xzfLNs81zzTTNNUz1jPYMtoy2zLcMt0y3THdMd0x3THcMdox2jH/OVA5UDpQPFBBUEhPTE9RT1tOYU5mTXFMeEt7S4dKj0iSSJxGpEWmRa9DuEG5QcI/yz7LPtQ83TveO+Y67TnuOPE38Tc=";
            byte[] decodedSignature = System.Convert.FromBase64String(parcelTrackSignature);
            List<string> signatureVector = new List<string>();
            String currentVector = "";
            Point currentPair = new Point { };
            bool firstDigitInPair = true;

            for (int i = 1; i < decodedSignature.Length; i++)
            {
                if (firstDigitInPair)
                {
                    currentPair = new Point { };

                    if (decodedSignature[i] == 255)
                    {
                        signatureVector.Add(currentVector);
                        currentVector = "";
                    }
                    else
                    {
                        currentPair.X = decodedSignature[i];
                        firstDigitInPair = false;
                    }
                }
                else
                {
                    currentPair.Y = decodedSignature[i];

                    if (!(currentPair.Y == 0 || currentPair.X == 0))
                    {
                        currentVector += currentPair.X + "," + currentPair.Y + " ";
                    }

                    firstDigitInPair = true;
                }
            }
            signatureVector.Add(currentVector);
        }
    }
}
