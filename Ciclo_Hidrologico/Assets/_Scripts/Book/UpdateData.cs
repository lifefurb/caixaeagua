
public enum type { DISSECTION, INFORMATION, VELOCITY };
// tipo de update que vai ser necessário
public class UpdateData {
    
    private int _page;
    public int Page {
        get {
            return _page;
        }
        set {
            _page = value;
        }
    }
}
