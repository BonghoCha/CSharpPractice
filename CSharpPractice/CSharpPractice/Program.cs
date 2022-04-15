using System;

namespace CSharpPractice
{
    class Program
    {
        class 데이터_갖고_놀기
        {
            public 데이터_갖고_놀기()
            {
                //// 정수형식

                // byte(1바이트 0~255), short(2바이트 -3만~3만), int(4바이트 -21억~21억), long(8바이트 얘는 넘사)
                // sbyte(1바이트 -128~127), ushort(2바이트 0~6만5천), uint(0~43억), ulong(8바이트 얘도 넘사)

                int hp;
                short level = 100;
                long id; // 아이템의 고유 식별 번호가 id로 저장 > 시간이 흐르니 21억이 넘어갔다.

                // 문명 > 간디 일화
                byte attack = 0;
                attack--;
                // 공격성을 표현하는 attack이라는 값이 0일 때, 1을 빼주니 byte 수 범위로 인해 0->255로 변했다.

                hp = 100;

                Console.WriteLine("Hello Number {0}", hp);


                //// 2진수, 10진수, 16진수 (진법)

                // 10진수
                // 00 01 02 03 04 05 06 07 08 09
                // 10

                // 2진수
                // 0~1
                // 0b00 0b01 0b10 0b11 0b100
                // b : 2진수인 것을 표현하기 위함(바이너리)

                // 16진수
                // 0~9 a b c d e f
                // 0x00 0x01 0x02 .. 0x0F
                // 0x10
                // x : 16진수인 것을 표현하기 위함(헥사)

                // 2진수 > 16진수 변환 : 맨 뒤에서부터 4개씩 끊어준다.
                // 0b10001111 = 0b 1000 1111
                //              0x 8    15   = 0x8F


                // Byte는 0b 0000 0000 으로 표현된다. 즉 최댓값은 0b 1111 1111 = 255기 때문에 0~255까지 표현가능하다.
                // Byte가 8자리인 이유는 딱히.. 모르겠.

                // 여기서 sByte의 경우에는 맨 앞자리를 음수로 사용한다. 즉 0b 1000 0001 = -1이다.
                // 2의 보수 : 최상위 비트(제일 왼쪽에 있는 수)를 음수로 사용
                // 1000 0000 = -128 이기 때문에 1111 1111 = -1이다.
                // (1000 0000 + 0111 1111) = (-128 + 127) = -1
                // 양수의 음수값을 찾기 위한 2의 보수 공식
                // 0은 1로, 1은 0으로, 그리고 1을 더해준다.
                // 예 :
                //      52  = 0011 0100
                //      -53 = 1100 1011 (그리고 0000 0001 더하기)
                //      -52 = 1100 1100

                //// 불리언, 소수, 문자, 문자열 형식

                // 코딩 컨벤션 -> 변수 규칙을 어떻게 정할지
                // bool : 1바이트(참/거짓)
                // 참 혹은 거짓이라는 두 가지 값만 같은데 왜 1바이트만 쓰는지 : 컴퓨터가 연산할 때 1비트보다 1바이트를 다루는게 훨씬 빠르다.

                bool b;
                b = true;
                b = false;

                // 소수

                // 4바이트
                // 기본적으로 소수를 double로 인식하기 때문에 f를 입력해줘야한다.
                // 약 7자리까지는 정확도가 높고 그 이후로는 낮아진다.
                // 정수 연산보다 조금 더 비용이 높다.
                float f = 3.14f;

                // 8바이트
                double d;

                // 2바이트
                // 캐릭터도 숫자를 저장하는 타입
                char c = 'a';
                // 캐릭터의 모
                string str = "Hello World";

                Console.WriteLine("str");


                //// 형식 변환
                // 1. 바구니 크기가 다른 경우!
                // 작은 크기에 큰 크기의 형식을 변환하는 경우
                // 일부가 분실되기 때문에 어떤 일이 일어날지 예상하기 어렵다.
                int a_1 = 1000;
                short b_1 = (short)a_1;

                int a_1_1 = 0x0FFFFFFF;
                Console.WriteLine("{0}", a_1_1);

                short b_1_1 = (short)a_1_1;
                // 이때 b_1_1에는 -1이 들어있.
                // 이유 :
                // a_1_1 = 0x 0FFF(2바이트) FFFF(2바이트) 
                // b_1_1 = 0x FFFF(2바이트 = short는 2바이트까지만 저장 가능)
                //       = -1 (상위 2바이트를 날린다)


                // 큰 크기에 작은 크기의 형식을 변환하는 경우
                // 큰 이슈가 없을 것으로 예상된다.
                int a_2 = 1000;
                short b_2 = 100;
                a_2 = b_2;

                // 2. 바구니 크기는 같긴 한, 부호가 다를 경우
                byte c_1 = 255;
                sbyte sb_1 = (sbyte)c_1;
                // 이때 sb_1에는 -1이 들어있다.
                // 이유 :
                // c_1  = 0b 1111 1111 = 255
                // sb_1 = 0b 1111 1111 = -1

                // 범위가 미달해서 이상한 값이 나오는 현상 : underflow
                // 범위가 초과해서 이상한 값이 나오는 현상 : overflow

                // 3. 소수
                float f_1 = 3.1414f;
                float d_1 = f_1;
                // 이때 d_1에는 3.1414000000000xx...가 할당된다.
                // 즉 float의 경우에는 입력한 최대한 근접한 값을 할당하는 경우가 많다.
                // 그래서 소수 변환을 할 때는 정확한 숫자가 아니라 인접한 숫자를 반환하기에 참고하여야 한다.
                // 소수를 비교할 때는 오차를 염두해두고 비교해야한다.

                //// 데이터 연산
                // + - * / %
                hp = 100 + 1;
                hp = 100 - 1;
                hp = 100 * 2;
                hp = 100 / 2;

                hp = 2 * 100 + 1;
                Console.WriteLine(hp); // 201;
                hp = (1 + 2) * 100;
                Console.WriteLine(hp); // 300;
                hp = 100 % 3;
                Console.WriteLine(hp); // 1;

                hp = 100;
                Console.WriteLine(hp++); // 100;
                Console.WriteLine(++hp); // 100;

                bool isActive = (hp > 0);
                bool isHighLevel = (level >= 40);

                // && : AND
                // || : OR
                // !  : NOT
                // a = 살아있는 고렙 유저인가요?
                bool user_a = isActive && isHighLevel;

                // b = 살아있거나, 고렙 유저이거나, 둘 중 하나인가요?
                bool user_b = isActive || isHighLevel;

                // c = 죽은 유저인가요?
                bool user_c = !isActive;

                //// 비트 연산
                int num = 1;

                // << >>
                num = num << 3;
                Console.WriteLine(num); // = 8 : 왼쪽으로 3 칸을 민다.

                num = 8;
                num = num >> 1;
                Console.WriteLine(num); // = 4 : 오른쪽으로 1 칸을 민다.

                // &(and) : 비교하는 두 비트가 같으면 1, 아니면 0
                // 1010 0010 & 0110 1011 = 0011 0110
                // |(or)  : 비교하는 두 비트 중 하나라도 참이면 1, 아니면 0
                // ^(xor) : 비교하는 두 비트가 다르면 1, 아니면 1
                // ~(not) : 하나의 자릿수를 반전

                int user_id = 123;
                // 넉넉한 32비트의 (예를 들어)4비트씩 정해진 정보를 넣는다.
                // 0000 0000 0000 0000
                // 타입 위치 ...
                // = 타입이 0001 이라면 0001 0000 0000 0000 되어야하는데
                // 묘하게 크기 때문에 쉬프트 연산을 이용한다.
                // 0003 을 << 쉬프트 연산

                int key = 401;
                // xor은 암호학에서 많이 사용한다.
                // 왜? xor은 두번 해주면 처음 값이 나온다는 특성이 있다.

                int result_1 = user_id ^ key;
                int result_2 = result_1 ^ key; // result_2 = user_id
                                               // 통신을 할 때 user_id에 key값을 xor 연산해서 전달하고
                                               // 전달받은 쪽에서도 숨겨진 key값를 다시 연산하여 user_id를 추출해낸다.
                                               // => 보안성을 높일 수 있다.

                //// 데이터 마무리
                int x;
                x = 100;

                int y;
                y = x;

                x += 1;
                x -= 1;
                x *= 1;
                x /= 1;
                x %= 1;
                x <<= 1;
                x >>= 1;
                x &= 1;
                x |= 1;
                x ^= 1;
            }
        }

        class 코드의_흐름_제어
        {
            public 코드의_흐름_제어() {
                int hp = 100;
                bool isDead = (hp <= 0);

                if (isDead)
                {
                    Console.WriteLine("You ar dead!");
                    Console.WriteLine("You ar dead!");
                    Console.WriteLine("You ar dead!");
                }
                //if (isDead == false)
                else
                {
                    Console.WriteLine("You are win!");
                }
                // if else, if if로 처리할지는 팀 내의 컨벤션에 맞추어 진행
                // if (condition), if ( condition )으로 처리할지도 팀 내의 컨벤션에 맞추어 진행

                int choice = 0; // 0:가위 1:바위 2:보

                /*
                if (choice == 0)
                    Console.WriteLine("가위입니다.");
                if (choice == 1)
                    Console.WriteLine("바위입니다.");
                if (choice == 2)
                    Console.WriteLine("보입니다.");
                */

                if (choice == 0)
                    Console.WriteLine("가위입니다.");
                else if (choice == 1)
                    Console.WriteLine("바위입니다.");
                else if (choice == 2)
                    Console.WriteLine("보입니다.");


                switch (choice)
                {
                    case 0:
                        Console.WriteLine("가위입니다.");
                        break;
                    case 1:
                        Console.WriteLine("바위입니다.");
                        break;
                    case 2:
                        Console.WriteLine("보입니다.");
                        break;
                    case 3:
                        Console.WriteLine("치트키입니다.");
                        break;
                    default:
                        Console.WriteLine("다 실패했습니다.");
                        break;
                }


                Random rand = new Random();
                int aiChoice = rand.Next(0, 3);  // 0~2사이의 랜덤 값
                int myChoice = Convert.ToInt32(Console.ReadLine());

                switch (myChoice)
                {
                    case 0:
                        Console.WriteLine("당신의 선택은 가위입니다.");
                        break;
                    case 1:
                        Console.WriteLine("당신의 선택은 바위입니다.");
                        break;
                    case 2:
                        Console.WriteLine("당신의 선택은 보입니다.");
                        break;
                }

                switch (aiChoice)
                {
                    case 0:
                        Console.WriteLine("컴퓨터의 선택은 가위입니다.");
                        break;
                    case 1:
                        Console.WriteLine("컴퓨터의 선택은 바위입니다.");
                        break;
                    case 2:
                        Console.WriteLine("컴퓨터의 선택은 보입니다.");
                        break;
                }

                // 승리 무승부 패배
                if (myChoice == aiChoice)
                {
                    Console.WriteLine("무승부입니다.");
                } else if (myChoice == 0 && aiChoice == 2)
                {
                    Console.WriteLine("승리입니다.");
                }
                else if (myChoice == 1 && aiChoice == 0)
                {
                    Console.WriteLine("승리입니다.");
                }
                else if (myChoice == 2 && aiChoice == 1)
                {
                    Console.WriteLine("승리입니다.");
                } else
                {
                    Console.WriteLine("패배입니다.");
                }

                //int SCISSORS = 0;
                //int ROCK = 1;
                //int PAPER = 2;
                const int SCISSORS = 0;
                const int ROCK = 1;
                const int PAPER = 2;
                // const = 상수화 시키는 방법
                // 이름이 겹치지 않도록 신경써야함.
                // 만약 그룹으로 묶고 싶다면 "열거형" 사용

                switch (myChoice)
                {
                    //case SCISSORS:
                    case (int)Choice.Scissors:
                        Console.WriteLine("당신의 선택은 가위입니다.");
                        break;
                    //case ROCK:
                    case (int)Choice.Rock:
                        Console.WriteLine("당신의 선택은 바위입니다.");
                        break;
                    //case PAPER:
                    case (int)Choice.Paper:
                        Console.WriteLine("당신의 선택은 보입니다.");
                        break;
                }

                int count = 5;

                while (count > 0)
                {
                    Console.WriteLine("Hello World : " + count);
                    count--;
                }

                string answer;
                do
                {
                    Console.WriteLine("강사님은 잘생기셨나요? (y/n) : ");
                    answer = Console.ReadLine();
                } while (answer != "y");

                int num = 5;

                bool isPrime = true;

                //for (초기화식; 조건식; 반복식)
                for (int i = 0; i<num; i++)
                {
                    // 실행 순서 : 초기화식 -> 조건식 -> {} 안에 내용 -> 반복식
                    Console.WriteLine("Hello World : " + i);

                    if ((num % i) == 0)
                    {
                        isPrime = false;
                        Console.WriteLine("소수가 아닙니다.");
                        break;
                    }

                    if (i % 3 == 0)
                    {
                        Console.WriteLine("3으로 나누어지는 수입니다.");
                        continue;
                    }
                }

                if (isPrime)
                    Console.WriteLine("소수입니다.");
                else
                    Console.WriteLine("소수가 아닙니다.");


                // 메소드 함수
                //한정자 반환형식 이름(매개변수목록)
                void HelloWorld()
                {
                    Console.WriteLine("Hello World");
                }

                HelloWorld();

                // 덧셈 함수
                //int Add(int a, int b);
                //{
                //    //return a + b;
                //    int result = a + b;
                //    return result;
                //}

                //void AddOne(int number)
                void AddOne(ref int number)
                {
                    number = number + 1;
                }

                int n = 0;
                //AddOne(n);
                Console.WriteLine(n); // 결과 : 0

                AddOne(ref n);
                Console.WriteLine(n); // 결과 : 1

                int a = 0;
                AddOne(ref a);

                void Divide(int a, int b, out int result1, out int result2)
                {
                    result1 = a / b;
                    result2 = a % b;
                }

                int num1 = 10;
                int num2 = 3;

                //int result1;
                //int result2;

                Divide(num1, num2, out var result1, out var result2);
                Console.WriteLine(result1);
                Console.WriteLine(result2);

                int reti = Add(2, 3);
                float retf = Add(2f, 3f);

                int retis = Add(2, 3, d: 10);
                // 선택적 매개변수는 호출 순서를 지켜야하지만, 이렇게 타겟팅하여 넘겨줄 수 있다.
            }

            int Add(int a, int b, int c = 0, int d = 0)
            {
                // c,d = 선택적 매개변수
                return a + b + c + d;
            }
            
            // 오버로딩
            float Add(float a, float b)
            {
                return a + b;
            }

            // 열거형
            enum Choice
            {
                Scissors = 0,
                Rock = 1,
                Paper = 2
            }
        }

        class 코드의_흐름_제어_연습문제
        {
            public 코드의_흐름_제어_연습문제(int type)
            {
                switch (type)
                {
                    case 1:
                        {
                            // 구구단
                            for (int i = 2; i <= 9; i++)
                            {
                                Console.WriteLine($"{i}단");
                                for (int j = 1; j <= 9; j++)
                                {
                                    Console.WriteLine($"{i} * {j} = {i * j}");
                                }
                                Console.WriteLine("");
                            }

                            break;
                        }
                    case 2:
                        {
                            // 별찍기 (피라미드)
                            for (int i = 0; i < 5; i++)
                            {
                                for (int j=0; j<=i; j++)
                                {
                                    Console.Write("*");
                                }

                                Console.WriteLine("");
                            }
                            break;
                        }
                    case 3:
                        {
                            // 팩토리얼

                            // for문으로 반환하는 형식
                            int Factorial(int n)
                            {
                                int result = 1;
                                for (int i=2; i<=n; i++)
                                {
                                    result *= i;
                                }
                                return result;
                            }

                            // 재귀함수를 사용하는 형
                            int Factorial_R(int n)
                            {
                                if (n == 1) return 1;

                                return n * Factorial(n-1);
                            }

                            Console.WriteLine("for : " + Factorial(5));
                            Console.WriteLine("recursive : " + Factorial_R(5));
                            break;
                        }
                }
            }
        }

        class TEXTRPG
        {
            enum ClassType
            {
                None = 0,
                Knight = 1,
                Archer = 2,
                Mage = 3
            }
            struct Player
            {
                public ClassType type;

                public int hp;
                public int attack;
            }

            enum MonsterType
            {
                None = 0,
                Slime = 1,
                Orc =2,
                Skeleton = 3
            }

            struct Monster
            {
                public MonsterType type;

                public int hp;
                public int attack;
            }

            ClassType ChooseClass()
            {
                Console.WriteLine("직업을 선택하세요.");
                Console.WriteLine("[1] 기사");
                Console.WriteLine("[2] 궁수");
                Console.WriteLine("[3] 법사");

                ClassType choice = ClassType.None;

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        {
                            choice = ClassType.Knight;
                            break;
                        }
                    case "2":
                        {
                            choice = ClassType.Archer;
                            break;
                        }
                    case "3":
                        {
                            choice = ClassType.Mage;
                            break;
                        }
                }

                return choice;
            }

            void CreatePlayer(ClassType choice, out Player player)
            {
                player.type = choice;

                switch (player.type)
                {
                    case ClassType.Knight:
                        {
                            player.hp = 100;
                            player.attack = 10;
                            break;
                        }
                    case ClassType.Archer:
                        {
                            player.hp = 75;
                            player.attack = 12;
                            break;
                        }
                    case ClassType.Mage:
                        {
                            player.hp = 50;
                            player.attack = 15;
                            break;
                        }
                    default: {
                            player.hp = 0;
                            player.attack = 0;
                            break;
                        }
                }
            }

            void CreateRandomMonster(out Monster monster)
            {
                Random rand = new Random();
                int randMonster = rand.Next(1, 4);                

                switch (randMonster)
                {
                    case (int)MonsterType.Slime:
                        Console.WriteLine("슬라임이 스폰되었습니다.");

                        monster.type = MonsterType.Slime;
                        monster.hp = 20;
                        monster.attack = 2;
                        break;
                    case (int)MonsterType.Orc:
                        Console.WriteLine("오크가 스폰되었습니다.");

                        monster.type = MonsterType.Orc;
                        monster.hp = 40;
                        monster.attack = 4;
                        break;
                    case (int)MonsterType.Skeleton:
                        Console.WriteLine("스켈레톤이 스폰되었습니다.");

                        monster.type = MonsterType.Skeleton;
                        monster.hp = 30;
                        monster.attack = 3;
                        break;
                    default:
                        monster.type = MonsterType.None;
                        monster.hp = 0;
                        monster.attack = 0;
                        break;
                }
            }
            void EnterGame(Player player)
            {
                while (true)
                {
                    Console.WriteLine("게임에 접속했습니다.");
                    Console.WriteLine("[1] 필드로 간다.");
                    Console.WriteLine("[2] 로비돌아간다.");

                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            {
                                EnterField(player);
                                break;
                            }
                        case "2":
                            {
                                return;
                            }
                    }
                }
            }

            void EnterField(Player player)
            {

                while (true)
                {
                    Console.WriteLine("필드에 접속했습니다.");
                    
                    // 랜덤으로 1~3 몬스터 중 하나를 리스폰
                    Monster monster;
                    CreateRandomMonster(out monster);

                    Console.WriteLine("[1] 전투 모드로 돌입");
                    Console.WriteLine("[2] 일정 확률로 마을로 도망");

                    string input = Console.ReadLine();

                    if (input == "1")
                    {
                        Fight(player, monster );
                    } else if (input == "2")
                    {

                    }
                }
            }

            void Fight(Player player, Monster monster)
            {

            }
            public TEXTRPG()
            {
                // 디버그
                // 브레이킹 포인트 설정 > F10(다음 라인), F11(메소드 안까지 디버그)                

                while (true)
                {
                    ClassType choice = ChooseClass();

                    if (!choice.Equals(ClassType.None))
                    {
                        Player player;

                        // 캐릭터를 선택했을 때 캐릭터 생성
                        CreatePlayer(choice, out player);

                        EnterGame(player);
                    }
                }
            }

            public int Add(int a, int b)
            {
                return a + b;
            }
        }

        static void Main(string[] args)
        {
            TEXTRPG t = new TEXTRPG();
        }
    }
}
