import edu.princeton.cs.algs4.StdRandom;
import edu.princeton.cs.algs4.StdStats;

public class PercolationStats {
    
    private int N, T, nn;
    private double[] results;
    private double mean, stddev;
    
    // perform T independent experiments on an N-by-N grid
   public PercolationStats(int N, int T)
   {
       this.N = N;
       this.T = T;
       nn = N*N;
       results = new double[T];
       
       for (int i = 0; i < T; i++) {
           run(i);
       }
       
       mean = StdStats.mean(results);
       stddev = StdStats.stddev(results);
   }
   
   // sample mean of percolation threshold
   public double mean()
   {
       return mean;
   }
   
   // sample standard deviation of percolation threshold
   public double stddev()
   {
       return stddev;
   }
   
   // low  endpoint of 95% confidence interval
   public double confidenceLo()
   {
       return mean - 1.96*stddev / Math.sqrt(T);
   }
   
   // high endpoint of 95% confidence interval
   public double confidenceHi()
   {
       return mean + 1.96*stddev / Math.sqrt(T);
   }
   
   private void run(int t) {
       Percolation p = new Percolation(N);
       
       int count = 0;
       
       while (!p.percolates() && count < nn) {
           
           int i;
           int j;
           do {
               i = StdRandom.uniform(N) + 1;
               j = StdRandom.uniform(N) + 1;
           } while (p.isOpen(i, j));
           
           
           p.open(i, j);
           
           count++;
       }
       
       results[t] = (double) count / (double) nn;
       
       //System.out.println(count + " " + nn + " " + results[t]);
   }

   public static void main(String[] args)    // test client (described below)
   {
       int N = Integer.parseInt(args[0]);
       int T = Integer.parseInt(args[1]);
       
       //System.out.println(N+ " " + T);
       
       if (N <= 0) { 
           throw new java.lang.IllegalArgumentException("N smaller equal to zero.");
       }

       if (T <= 0) { 
           throw new java.lang.IllegalArgumentException("T smaller equal to zero.");
       }

       PercolationStats ps = new PercolationStats(N, T);
       
       System.out.println("mean                    = " + ps.mean());
       System.out.println("stddev                  = " + ps.stddev());
       System.out.println("95% confidence interval = " 
                              + ps.confidenceLo()+", "+ps.confidenceHi());
   }
}