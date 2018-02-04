/**
 *
 * @author David
 */
public class LibraryApp {

    public static void main(String[] args) {
        Student student = new Student("Jon Java");
        student.setEmail("jj@nscc.ca:");
        
        System.out.println("Student Email:");
        System.out.println(student.getEmail() +"\n");
        
        LibraryCard card = new LibraryCard(1);
        card.setOwner(student);
        card.checkOut(3);
        //card.checkOut(5);
        
        System.out.println("Card Info");
        System.out.println(card.reportMe() +"\n");
        
    }
    
}
