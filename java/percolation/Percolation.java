import edu.princeton.cs.algs4.WeightedQuickUnionUF;
    
public class Percolation {
    
   private int N, nn, virtTop, virtBottom;
   private boolean[] grid;
   private WeightedQuickUnionUF uf;
    
    // create N-by-N grid, with all sites blocked
   public Percolation(int N)               
   {
       if (N <= 0) { throw new java.lang.IllegalArgumentException(); }
       
       this.N = N;
       nn = N*N;
       virtTop = 0;
       virtBottom = nn+1;
       grid = new boolean[nn];
       uf = new WeightedQuickUnionUF(nn + 2); //plus 2 for virtual sites
       
       for (int i = 0; i < nn; i++) {
           grid[i] = false;
       }
   }
   
   // open site (row i, column j) if it is not open already
   public void open(int i, int j)
   {
       checkOutOfBounds(i, j);

       int indexGrid = xyTo1DGrid(i, j);
       int indexUF = xyTo1DUF(i, j);
       
       grid[indexGrid] = true;
       
       if (i > 1) {
           union(indexUF, i-1, j);
       }
       
       if (i < N) {
           union(indexUF, i+1, j);
       }
       
       if (j > 1) {
           union(indexUF, i, j-1);
       }
       
       if (j < N) {
           union(indexUF, i, j+1);
       }
       
       //first row ? connect to top virtual site
       if (i == 1) {
           //System.out.println("connecting to top indexUF="+indexUF);
           uf.union(indexUF, virtTop);
       }
       
       //last row? connect to bottom virtual site
       if (i == N) {
           uf.union(indexUF, virtBottom);
       }
       
   }
   
   // is site (row i, column j) open?
   public boolean isOpen(int i, int j)     
   {
       checkOutOfBounds(i, j);
       int indexGrid = xyTo1DGrid(i, j);
       return grid[indexGrid];
   }
   
   // is site (row i, column j) full?
   public boolean isFull(int i, int j)
   {
       checkOutOfBounds(i, j);
       boolean x = uf.connected(virtTop, xyTo1DUF(i, j));
       //if (x) {
       //System.out.println(i + " " + j + " " + x);
       //}
       return isOpen(i, j) && x;
   }
   
   // does the system percolate?
   public boolean percolates()  {
       return uf.connected(virtTop, virtBottom);
   }
   
   private void checkOutOfBounds(int i, int j) {
       checkOutOfBound(i, "row", "i");
       checkOutOfBound(j, "column", "j");
   }
   
   private void checkOutOfBound(int i, String type, String name) {
       if (i <= 0 || i > N) {
           throw new IndexOutOfBoundsException(type+" index "+name+" out of bounds");
       }
   }
   
   private int xyTo1DGrid(int row, int column) {
       return (row-1)*N+column-1; //ZERO based!!!
   }

   private int xyTo1DUF(int row, int column) {
       return xyTo1DGrid(row, column)+1;
   }
   
   private void union(int indexUF, int i, int j) {
       if (isOpen(i, j)) {
               uf.union(indexUF, xyTo1DUF(i, j));
           }
   }
   
   // test client (optional)
   public static void main(String[] args)  {
       testXYTo1D();
       testOpen();
       testIsFull();
   }
   
   private static void testXYTo1D() {
       System.out.println("testXYTo1D");
       Percolation p = new Percolation(10);
       assert p.xyTo1DGrid(1, 1) == 0;
       assert p.xyTo1DGrid(1, 10) == 9;
       assert p.xyTo1DGrid(2, 1) == 10;
       assert p.xyTo1DGrid(3, 4) == 23;
       assert p.xyTo1DGrid(10, 10) == 99;
   }
   
   private static void testOpen() {
       System.out.println("testOpen");
       Percolation p = new Percolation(10);
       p.open(1, 1);
       p.open(1, 2);
       assert p.uf.connected(p.xyTo1DUF(1, 1), p.xyTo1DUF(1, 2));
   }
   
   private static void testIsFull() {
       System.out.println("testIsFull");
       Percolation p = new Percolation(10);
       
       assert !p.isFull(1, 1);
       p.open(1, 1);
       assert p.isFull(1, 1);
       
       assert !p.isFull(2, 2);  
       p.open(2, 2);
       assert !p.isFull(2, 2);
   }
}