package ca.seanmorrow.insultgenerator;


public class HelpPresenter {
    private HelpView helpView;
    private Generator generator;

    public HelpPresenter(HelpView myHelpView) {
        helpView = myHelpView;
        generator = Generator.getInstance();
        helpView.updateCount(generator.getInsultCount());
        generator.setInsultCount(0);
    }

}
