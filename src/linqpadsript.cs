Matrix<double> p;
Vector<double> t;
			
var distr = new MathNet.Numerics.Distributions.ContinuousUniform(0.0, 1.0);
			int seed1 = 342;
			distr.RandomSource = new Random(seed1);
						Matrix<double> noMeaning = new DenseMatrix(1, 1);
			p = noMeaning.Random(7, 2000, distr) as DenseMatrix;
		
		    //p(2.0,c_p)=zeros(1.0,2000.0);
			p.SetRowI(2, new DenseVector(2000, 0) as Vector<double>);
			//p(3.0,c_p)=p(1.0,c_p);    
			p.SetRowI(3, p.RowI(1));  
			//p(6.0,c_p)=zeros(1.0,2000.0);
			p.SetRowI(6, new DenseVector(2000, 0) as Vector<double>);

			////t=p(1.0,c_p)+0.3*p(2.0,c_p)+0.28*randM(1.0,2000.0)+p(7.0,c_p);
			int seed2 = 1501;
			distr.RandomSource = new Random(seed2);
			var randv2 = noMeaning.Random(1, 2000, distr).RowI(1);
			t = p.RowI(1) + 0.3 * p.RowI(2) + 0.28 * randv2 + p.RowI(7);

			Regression rega = new Regression(p,t);
			rega.bestsubsets(4,0);
			