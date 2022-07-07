// StringBuilder를 사용할때는 버퍼사이즈를 적당히 주는게 좋음.
// 최종적으로 ToString()시 성능 저하 방지를 위함.
// 문자열이 추가 될때마다 버퍼를 추가하고, 링크드 리스트로 관리하기때문에 여러 버퍼로 쪼개서 저장되고,
// ToString()시 각 버퍼를 찾아 문자열을 만들어 주기 때문임.
// 또한 Append()시 새 버퍼에 할당하는 작업을 줄 일 수 있음.
// http://www.simpleisbest.net/post/2013/04/24/Review-StringBuilder.aspx

using System.Text;

const int dataSize = 200;

var sb = new StringBuilder(dataSize);
sb.Append(Guid.NewGuid().ToString());
sb.Append(Guid.NewGuid().ToString());
sb.Append(Guid.NewGuid().ToString());

Console.WriteLine(sb.ToString());
