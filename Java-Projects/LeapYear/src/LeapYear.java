/**
 *
 * @author David
 */
public class LeapYear extends LeapYearGUI {
    private static String outPutYear;
    private int yearIs;
    
    public LeapYear(String year) {

        
        yearIs = Integer.parseInt(year);
        // Error check
        if (yearIs >=  1582){
            
            // Calculation
            if ((yearIs % 4 ==0) && (yearIs % 100 != 0)) {
                outPutYear = (year + "Is a Leap Year");
            }
            else if ((yearIs % 4 == 0) && (yearIs % 100 == 0) && (yearIs % 400 == 0)){
                outPutYear = (year + " Is a Leap Year");
            }
            else{
                outPutYear = (year + " Is not a Leap Year");
            }
        }
        else{
            outPutYear = (year + " Is not a Valid Year most be a number and be before 1581");
        }
    }
    public static String getOutPutYear(){
            return outPutYear;
    }

    }
