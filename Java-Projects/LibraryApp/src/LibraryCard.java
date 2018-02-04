/**
 *
 * @author David
 */
public class LibraryCard {
    public static final int MAX_BOOKS = 5;
    private int borrowCount;
    private Student owner;
    public LibraryCard(int numOfBooks) {
        borrowCount = 0;
        checkOut(numOfBooks);
    }
    
    public int getBorrowCount() {
        return borrowCount;
    }
    public void setOwner(Student student) {
        owner = student;
    }
    public String getOwnerName() {
        if (owner != null) {
        return owner.getName();
        
        }else {
            return "not Set";
        }
        
    }
    
    public void checkOut(int numOfBooks) {
        borrowCount = borrowCount + numOfBooks;
        if (borrowCount > MAX_BOOKS) {
            borrowCount = MAX_BOOKS; 
        }
    }
    
}
 public String reportMe() {
if (owner != null) {
return "    Owner Name:" + owner.getName() +


}
}