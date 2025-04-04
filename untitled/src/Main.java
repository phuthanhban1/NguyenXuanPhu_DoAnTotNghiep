import java.util.ArrayList;
import java.util.List;

//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
public class Main {
    public static void main(String[] args) {
        Parent p = new Child();  // Upcasting: Biến kiểu Parent tham chiếu đến đối tượng Child
        Child c = new Child();
        //p.show();  // Output: "Child method" (Vì phương thức bị ghi đè - method overriding)

        //p.display(); //
        List<Parent> a = new ArrayList<Parent>();
        a.add(p);
        a.add(c);
    }
}

class Parent {
    void show() {
        System.out.println("Parent method");
    }
}

class Child extends Parent {
    void show() {
        System.out.println("Child method");
    }

    void display() {
        System.out.println("Child specific method");
    }
}

