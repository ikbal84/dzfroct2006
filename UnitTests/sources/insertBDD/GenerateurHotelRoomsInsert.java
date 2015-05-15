import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.util.Random;


public class GenerateurHotelRoomsInsert {

	public static String generateurInsert() {
		String[] listeRoom = {"Simple","Double","Double Luxe","Double Supreme","Triple","Suite","Suite Luxe", "Sultan", "Extra", "Mono"};
		Random random = new Random();
		StringBuilder insertReq = new StringBuilder();
		
		insertReq.append("USE [HotelsDB]\n");
        insertReq.append("GO\n");
        for (int i=1; i < 60; i++ ) {
		insertReq.append("INSERT INTO [dbo].[HotelRooms] ("
				+ "[RoomType]"
				+ ",[Description]"
				+ ",[NbPersonnes]"
				+ ",[NbRooms]"
				+ ",[Price]"
				+ " ,[Hotel_HotelID])"
				);
		insertReq.append(" VALUES "
				+ " ( '"+listeRoom[random.nextInt(7)]+"'"		
				+ ",'Chambre de type..'"
				+ ",'"+random.nextInt(5)+"'"
				+ ",'"+random.nextInt(10)+"'"
				+ ",'"+random.nextInt(30000)+" DA'"
		        + ",'"+random.nextInt(30)+"'"
				+")\n");
        }
		insertReq.append("GO");
		
		return insertReq.toString();

	}
	
	public static void main(String[] args) throws IOException{
		File file = new File("insertHotelRooms.sql");
		if(file.exists()) {
			file.delete();
		}
		System.out.println(file.getAbsolutePath());
		file.createNewFile();
		BufferedWriter bWriter = new BufferedWriter(new FileWriter(file));
		bWriter.write(generateurInsert());
		bWriter.close();
	}
}
