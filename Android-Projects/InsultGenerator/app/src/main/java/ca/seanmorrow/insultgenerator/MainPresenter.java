package ca.seanmorrow.insultgenerator;

public class MainPresenter {
    private MainView mainView;
    private Generator generator;

    public MainPresenter(MainView myMainView) {
        mainView = myMainView;
        // construct model or get model
        generator = Generator.getInstance();
        generator.setResources(mainView.getResources());
        mainView.showInsult(generator.getInsult());
    }

    // --------------------------------------------- public methods
    public void generate() {
        String victim = mainView.getVictim();
        if (victim.equals("")) {
            mainView.showError();
        } else {
            String insult = generator.hitMe(victim);
            mainView.showInsult(insult);
        }
    }

    public void clear() {
        generator.reset();
        mainView.reset();
    }

    public void help() {
        mainView.showHelpPopup();
    }

}
