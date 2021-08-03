// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 


using Morphfolia.Common.Info;


namespace Morphfolia.Common.Info
{


    /// <summary>
    /// The WordIndexAlphabet stores a library of words which have been collected, indexed and are ready to be stored.
    /// </summary>
    public class WordIndexAlphabet
    {

        /// <summary>
        /// Holds references to all the WordIndexInfoCollections for easy iteration.
        /// </summary>
        public WordIndexInfoCollection[] WordIndexes;


        private int pageId = Common.Constants.SystemTypeValues.NullInt;
        public int PageId
        {
            get { return pageId; }
            set { pageId = value;  }
        }

        private int contentId = Common.Constants.SystemTypeValues.NullInt;
        public int ContentId
        {
            get { return contentId; }
            set { contentId = value; }
        }



        /// <summary>
        /// Holds words starting with characters other than a-z, such as numbers and special characters.
        /// </summary>
        public WordIndexInfoCollection Other;
        /// <summary>
        /// Holds words starting with the letter A.
        /// </summary>
        public WordIndexInfoCollection A;
        /// <summary>
        /// Holds words starting with the letter A.
        /// </summary>
        public WordIndexInfoCollection B;
        /// <summary>
        /// Holds words starting with the letter A.
        /// </summary>
        public WordIndexInfoCollection C;
        /// <summary>
        /// Holds words starting with the letter A.
        /// </summary>
        public WordIndexInfoCollection D;
        /// <summary>
        /// Holds words starting with the letter A.
        /// </summary>
        public WordIndexInfoCollection E;
        /// <summary>
        /// Holds words starting with the letter A.
        /// </summary>
        public WordIndexInfoCollection F;
        /// <summary>
        /// Holds words starting with the letter A.
        /// </summary>
        public WordIndexInfoCollection G;
        /// <summary>
        /// Holds words starting with the letter A.
        /// </summary>
        public WordIndexInfoCollection H;
        /// <summary>
        /// Holds words starting with the letter A.
        /// </summary>
        public WordIndexInfoCollection I;
        /// <summary>
        /// Holds words starting with the letter A.
        /// </summary>
        public WordIndexInfoCollection J;
        /// <summary>
        /// Holds words starting with the letter A.
        /// </summary>
        public WordIndexInfoCollection K;
        /// <summary>
        /// Holds words starting with the letter A.
        /// </summary>
        public WordIndexInfoCollection L;
        /// <summary>
        /// Holds words starting with the letter A.
        /// </summary>
        public WordIndexInfoCollection M;
        /// <summary>
        /// Holds words starting with the letter A.
        /// </summary>
        public WordIndexInfoCollection N;
        /// <summary>
        /// Holds words starting with the letter A.
        /// </summary>
        public WordIndexInfoCollection O;
        /// <summary>
        /// Holds words starting with the letter A.
        /// </summary>
        public WordIndexInfoCollection P;
        /// <summary>
        /// Holds words starting with the letter A.
        /// </summary>
        public WordIndexInfoCollection Q;
        /// <summary>
        /// Holds words starting with the letter A.
        /// </summary>
        public WordIndexInfoCollection R;
        /// <summary>
        /// Holds words starting with the letter A.
        /// </summary>
        public WordIndexInfoCollection S;
        /// <summary>
        /// Holds words starting with the letter A.
        /// </summary>
        public WordIndexInfoCollection T;
        /// <summary>
        /// Holds words starting with the letter A.
        /// </summary>
        public WordIndexInfoCollection U;
        /// <summary>
        /// Holds words starting with the letter A.
        /// </summary>
        public WordIndexInfoCollection V;
        /// <summary>
        /// Holds words starting with the letter A.
        /// </summary>
        public WordIndexInfoCollection W;
        /// <summary>
        /// Holds words starting with the letter A.
        /// </summary>
        public WordIndexInfoCollection X;
        /// <summary>
        /// Holds words starting with the letter A.
        /// </summary>
        public WordIndexInfoCollection Y;
        /// <summary>
        /// Holds words starting with the letter A.
        /// </summary>
        public WordIndexInfoCollection Z;



        public WordIndexAlphabet()
        {
            WordIndexes = new WordIndexInfoCollection[27];

            A = new WordIndexInfoCollection();
            A.FirstCharacter = char.Parse("A");
            WordIndexes.SetValue(A, 0);

            B = new WordIndexInfoCollection();
            B.FirstCharacter = char.Parse("B");
            WordIndexes.SetValue(B, 1);

            C = new WordIndexInfoCollection();
            C.FirstCharacter = char.Parse("C");
            WordIndexes.SetValue(C, 2);

            D = new WordIndexInfoCollection();
            D.FirstCharacter = char.Parse("D");
            WordIndexes.SetValue(D, 3);

            E = new WordIndexInfoCollection();
            E.FirstCharacter = char.Parse("E");
            WordIndexes.SetValue(E, 4);

            F = new WordIndexInfoCollection();
            F.FirstCharacter = char.Parse("F");
            WordIndexes.SetValue(F, 5);

            G = new WordIndexInfoCollection();
            G.FirstCharacter = char.Parse("G");
            WordIndexes.SetValue(G, 6);

            H = new WordIndexInfoCollection();
            H.FirstCharacter = char.Parse("H");
            WordIndexes.SetValue(H, 7);

            I = new WordIndexInfoCollection();
            I.FirstCharacter = char.Parse("I");
            WordIndexes.SetValue(I, 8);

            J = new WordIndexInfoCollection();
            J.FirstCharacter = char.Parse("J");
            WordIndexes.SetValue(J, 9);

            K = new WordIndexInfoCollection();
            K.FirstCharacter = char.Parse("K");
            WordIndexes.SetValue(K, 10);

            L = new WordIndexInfoCollection();
            L.FirstCharacter = char.Parse("L");
            WordIndexes.SetValue(L, 11);

            M = new WordIndexInfoCollection();
            M.FirstCharacter = char.Parse("M");
            WordIndexes.SetValue(M, 12);

            N = new WordIndexInfoCollection();
            N.FirstCharacter = char.Parse("N");
            WordIndexes.SetValue(N, 13);

            O = new WordIndexInfoCollection();
            O.FirstCharacter = char.Parse("O");
            WordIndexes.SetValue(O, 14);

            P = new WordIndexInfoCollection();
            P.FirstCharacter = char.Parse("P");
            WordIndexes.SetValue(P, 15);

            Q = new WordIndexInfoCollection();
            Q.FirstCharacter = char.Parse("Q");
            WordIndexes.SetValue(Q, 16);

            R = new WordIndexInfoCollection();
            R.FirstCharacter = char.Parse("R");
            WordIndexes.SetValue(R, 17);

            S = new WordIndexInfoCollection();
            S.FirstCharacter = char.Parse("S");
            WordIndexes.SetValue(S, 18);

            T = new WordIndexInfoCollection();
            T.FirstCharacter = char.Parse("T");
            WordIndexes.SetValue(T, 19);

            U = new WordIndexInfoCollection();
            U.FirstCharacter = char.Parse("U");
            WordIndexes.SetValue(U, 20);

            V = new WordIndexInfoCollection();
            V.FirstCharacter = char.Parse("V");
            WordIndexes.SetValue(V, 21);

            W = new WordIndexInfoCollection();
            W.FirstCharacter = char.Parse("W");
            WordIndexes.SetValue(W, 22);

            X = new WordIndexInfoCollection();
            X.FirstCharacter = char.Parse("X");
            WordIndexes.SetValue(X, 23);

            Y = new WordIndexInfoCollection();
            Y.FirstCharacter = char.Parse("Y");
            WordIndexes.SetValue(Y, 24);

            Z = new WordIndexInfoCollection();
            Z.FirstCharacter = char.Parse("Z");
            WordIndexes.SetValue(Z, 25);

            Other = new WordIndexInfoCollection();
            Other.FirstCharacter = char.Parse("?");
            WordIndexes.SetValue(Other, 26);
        }


        /// <summary>
        /// Empties all the WordIndexInfoCollections.
        /// </summary>
        public void ClearAll()
        {
            for (int i = 0; i < WordIndexes.Length; i++)
            {
                WordIndexes[i].Clear();
            }
        }

    }

}