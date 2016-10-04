# HorrorGame

## Commit Style
### 1. Commit Message
>
원래는 "[이름]:메시지" 같은 형식을 사용했지만, 깃허브나 소스트리 등 다른 프로그램에서 커밋 작성자가 누군지 쉽게 확인할 수 있으므로 원래대로 메시지만 입력하도록 한다. 메시지의 내용은 자세할수록 좋다.


## C# Style
> https://github.com/raywenderlich/c-sharp-style-guide 를 참고한다.

### 1. 괄호

    // Good
    if () {
    }
    
    // BAD
    if ()
    {
    }

### 2. Early Return

    // Good
    void Boo() {
      if (temp == null) {
		  return;
	  }
    ...
    
    //BAD
    void Boo() {
      if (temp != null) {
        ...
      } else {
        return;
      }
     }

### 3. Naming

    // Good
    void Boo() {
      int temp;
      int redApple;
    }
    
    // BAD
    void boo() {
      int Temp;
      int red_apple;
    }

> 함수는 대문자로 시작, 변수는 소문자로 시작한다.
> 변수를 구성하는 단어가 하나 이상일 때는 _가 아닌 대문자로 구분한다.
