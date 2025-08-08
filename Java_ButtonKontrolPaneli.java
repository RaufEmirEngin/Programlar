import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class ButtonControlPanel extends JFrame {

  public ButtonControlPanel() {
    initializeUI();
  }

  private void initializeUI() {
    setTitle("Button Control Panel");
    setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
    setLayout(new GridLayout(4, 4, 5, 5));

    for (int i = 0; i < 16; i++) {
      CustomButton button = new CustomButton("Button " + (i + 1));
      add(button);
    }

    pack();
    setLocationRelativeTo(null);
  }

  private class CustomButton extends JButton {
    private String graphqlSchema;
    private Color activeColor;
    private Color passiveColor;
    private Icon activeIcon;
    private Icon passiveIcon;

    public CustomButton(String text) {
      super(text);
      // Özelliklerin varsayılan değerleri atanabilir.

      addActionListener(new ActionListener() {
        @Override
        public void actionPerformed(ActionEvent e) {
          handleClick();
        }
      });
    }

    public void setGraphqlSchema(String graphqlSchema) {
      this.graphqlSchema = graphqlSchema;
    }

    public void setActiveColor(Color activeColor) {
      this.activeColor = activeColor;
    }

    public void setPassiveColor(Color passiveColor) {
      this.passiveColor = passiveColor;
    }

    public void setActiveIcon(Icon activeIcon) {
      this.activeIcon = activeIcon;
    }

    public void setPassiveIcon(Icon passiveIcon) {
      this.passiveIcon = passiveIcon;
    }

    private void handleClick() {
      // Buton tıklandığında GraphQL şemasında bir mutation çalıştırabilirsiniz.
      // Bu örnekte bir mesaj yazdırıyoruz.
      System.out.println("Button Clicked: " + getText() + " - Running GraphQL mutation: " + graphqlSchema);

      // Butonun görünümünü güncelle
      updateButtonAppearance();
    }

    private void updateButtonAppearance() {
      // Butonun görünümünü güncelleme mantığını buraya ekleyin.
      // Örneğin, tüm butonların rengini pasif renge ayarlayabilir ve sadece tıklananı aktif renge çevirebilirsiniz.
      // Ayrıca simge veya metin içeriğini dinamik olarak güncelleyebilirsiniz.
    }
  }

  public static void main(String[] args) {
    SwingUtilities.invokeLater(new Runnable() {
      @Override
      public void run() {
        new ButtonControlPanel().setVisible(true);
      }
    });
  }
}