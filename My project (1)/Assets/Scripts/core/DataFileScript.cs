using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class DataFileScript : MonoBehaviour
{
    //For Mail
    public Text Details;
    public InputField First_name;
    public InputField Second_name;
    public InputField Third_name;


    //For slider
    public Slider Time_slider;

    //for buttons
    public Button[] Answers_buttons;
    public Button Menu_exit;
    public Button Email_Send_Button;
    public Button Immage_file_on_button;

    //for clock
    public Text Timer_text_space;
    public Text Timer_text_set;
    public float Start_timer_value = 60;
    bool timer_run = false;

    public float score = 0;
    public QuestionList[] questions;
    public Text Ask_me;
    public Text[] Answers_text;
    public int Ask_number = 1;

    List<object> Ask_List;
    QuestionList Current_Ask;

    int Ask_count;
    int Random_ask_index;

    private void Start()
    {
        Timer_text_set.text = Start_timer_value.ToString();
    }
    public void Set_Timer_up()
    {
        Start_timer_value += 10;
        Timer_text_set.text = Start_timer_value.ToString();
    }

    public void Set_Timer_down()
    {
        Start_timer_value -= 10;
        Timer_text_set.text = Start_timer_value.ToString();
    }


    public void Show_Immage_script()
    {
        if (Current_Ask.Immage_flag)
        {
            Current_Ask.Immage_file[0].SetActive(true);
        }
    }

    public void Show_Immage_Button_script()
    {
        if (Current_Ask.Immage_flag)
        {
            Immage_file_on_button.gameObject.SetActive(true);
        }
    }

    public void Hide_Immage_script()
    {
        if (Current_Ask.Immage_flag)
        {
            Current_Ask.Immage_file[0].SetActive(false);
        }
    }
    public void Start_Timer()
    {
        Details.text += "\n" + "Значение таймера: " + Start_timer_value.ToString() + "\n" ;
        Time_slider.maxValue = Start_timer_value;
        Timer_text_space.text = Start_timer_value.ToString();
        timer_run = true;
    }

    public void Next_Value()
    {
        if (timer_run)
        {
            Start_timer_value -= Time.deltaTime;
            Timer_text_space.text = Mathf.Round(Start_timer_value).ToString();
            Time_slider.value = Start_timer_value;
            if(Start_timer_value <= 0)
            {
                timer_run = false;
            }
        }        
    }

    public void Input_Details(int Button_Index, bool Correct_Flag)
    {
        Details.text += "Вопрос №" + Ask_number + "\n";
        Ask_number++;
        Details.text += "Вопрос: " + Ask_me.text + "\n";
        Details.text += "Ответ: " + Answers_text[Button_Index].text.ToString() + "\n";
        if (Correct_Flag)
        {
            Details.text += "Корректность: Верно \n";
        }
        else
        {
            Details.text += "Корректность: Не верно \n";
        }
        Details.text += "___________\n";

    }


    public void On_Start_click()
    {
        Details.text = Ask_me.text + "\n";
        Details.text += "Фамилия: " + First_name.text + "\n";
        Details.text += "Имя: " + Second_name.text + "\n";
        Details.text += "Отчество: " + Third_name.text + "\n";
        Details.text += "------------------------------" + "\n";
        Ask_List = new List<object>(questions);
        Generate_new_ask();
        Ask_count = Ask_List.Count;
        //print(Ask_count);
        Start_Timer();
    }

    void Generate_new_ask()
    {
        if ((Ask_List.Count > 0) && (Start_timer_value > 0))
        {
            Random_ask_index = Random.Range(0, Ask_List.Count);
            Current_Ask = Ask_List[Random_ask_index] as QuestionList;
            Ask_me.text = Current_Ask.question;
            List<string> Answer_List = new List<string> (Current_Ask.answers);
            for (int i = 0; i < Current_Ask.answers.Length; ++i)
            {
                int random_answer = Random.Range(0, Answer_List.Count);
                Answers_text[i].text = Answer_List[random_answer];
                Answer_List.RemoveAt(random_answer);
                //Answers_text[i].text = Current_Ask.answers[i];
            }
            if (Current_Ask.Immage_flag)
            {
                Show_Immage_Button_script();
            }
            else
            {
                Hide_Immage_script();
            }
        }
        else
        {
            for (int i = 0; i < Current_Ask.answers.Length; ++i)
            {
                Answers_buttons[i].gameObject.SetActive(false);
            }
            timer_run = false;
            Timer_text_space.gameObject.SetActive(false);
            Time_slider.gameObject.SetActive(false);
            
            float persent = score/Ask_count*100;
            Ask_me.text = "Тестирование завершено\n" + "Колличество правильных ответов: " + score + "\n";
            Ask_me.text += "Процент правильных ответов: " + persent + "%\n";
            int mark;
            if (persent < 50) mark = 2;
            else if (persent < 75) mark = 3;
            else if (persent < 85) mark = 4;
            else mark = 5;

            Ask_me.text += "ОЦЕНКА: " + mark;

            Immage_file_on_button.gameObject.SetActive(false);
            Menu_exit.gameObject.SetActive(true);
            Email_Send_Button.gameObject.SetActive(true);
        }
        
    }

    public void On_Answer_clik(int index_button)
    {
        if (Answers_text[index_button].text.ToString() == Current_Ask.answers[0]) {
            print("Correct Answer");
            Input_Details(index_button, true);
            score++;
        }
        else
        {
            print("Not correct Answer");
            Input_Details(index_button, false);
        }
        Ask_List.RemoveAt(Random_ask_index);
        Generate_new_ask();

    }

    // Update is called once per frame
    void Update()
    {
        Next_Value();
    }
}


[System.Serializable]
public class QuestionList
{
    public string question;
    public string[] answers = new string[3];
    //For immage
    public GameObject[] Immage_file = new GameObject[1];
    public bool Immage_flag;
    //public Image Immage_file;
}
