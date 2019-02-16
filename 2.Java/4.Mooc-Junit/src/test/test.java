import org.junit.Test;

import static org.junit.Assert.assertEquals;

public class test {
    @Test
    public void testAdd() {
        assertEquals(false,new SanJiao().correct(-1,2,3));
    }
    @Test
    public void testdelte() {
        assertEquals(true,new SanJiao().correct(-1,2,3));
    }

    @Test
    public void testd() {
        assertEquals("false",new SanJiao().correct(-1,2,3));
    }
}
