import pymorphy2
from pymorphy2 import MorphAnalyzer
from nltk import word_tokenize
import gensim
import gensim.downloader as api
import string
from nltk.corpus import stopwords


# функция подготовки текста для метода n_similarity()
# причем текст - одно предложение
def proc_text(text):
    print(f"\n------------\nИсходный текст: {text}")
    # предполагается, что тексты на входе стостоят из одного предложения
    word_tok_text = word_tokenize(text)     # тоекнизируем предложение по словам
    word_tok_text = [word for word in word_tok_text if word not in stopwords.words('russian')]    # очистка от стопслов
    word_tok_text = [word.lower() for word in word_tok_text]    # приводим к нижнему регистру
    morph = MorphAnalyzer()     # создаем анализатор
    word_tok_text = [morph.parse(word)[0].normal_form + "_" + morph.parse(word)[0].tag.POS for word in word_tok_text] # приводим к нормальной форме слова
    # ЕЩЕ в конец добавляем часть речи, ну и обрабатываем если это:
    # прилаагтельное: ADJF -> ADJ;
    for i in range(len(word_tok_text)):
        if "ADJF" in word_tok_text[i] or "ADJS" in word_tok_text[i] or "NUMR" in word_tok_text[i]:    # ПРИЛАГАТЕЛЬНОЕ + ЧИСЛИТЕЬНОЕ
            word_tok_text[i] = word_tok_text[i][:len(word_tok_text[i]) - 1:]
        if "NPRO" in word_tok_text[i]:  # МЕСТОИМЕНИЕ
            word_tok_text[i] = word_tok_text[i][:len(word_tok_text[i]) - 4:] + "PRON"
        if "ADVB"  in word_tok_text[i]:  # НАРЕЧИЕ
            word_tok_text[i] = word_tok_text[i][:len(word_tok_text[i]) - 4:] + "ADV"
        if "INFN" in word_tok_text[i] or "PRTS" in word_tok_text[i] or "PRTF" in word_tok_text[i]  or "GRND" in word_tok_text[i]: # ИНФИНИТИВ
            word_tok_text[i] = word_tok_text[i][:len(word_tok_text[i]) - 4:] + "VERB"
    print(f"Подготовленный текст: {word_tok_text}\n------------\n")
    return word_tok_text


model = api.load("word2vec-ruscorpora-300")

# # вывод 5 слов, наиболее сходных к слову "питон", и степень сходства
# result = model.most_similar("питон_NOUN")[:5]
# print("5 наиболее сходных слов к слову \"питон\":")
# for item in result:
#     print(item)
#
# # вывод 5 слов, наиболее сходных к слову "обворожительный", и степень сходства
# result = model.most_similar("обворожительный_ADJ")[:5]
# print("\n5 наиболее сходных слов к слову \"обворожительный\":")
# for item in result:
#     print(item)
#
# # вывод 5 слов, наиболее сходных к слову "изучать", и степень сходства
# result = model.most_similar("изучать_VERB")[:5]
# print("\n5 наиболее сходных слов к слову \"изучать\":")
# for item in result:
#     print(item)
#
# # слова, наиболее близкие к нескольким словам
# result = model.most_similar(positive=["питон_NOUN", "обворожительный_ADJ"], topn=5)
# print("\n5 наиболее сходных слов к словам \"питон\" и \"обворожительный\":")
# for item in result:
#     print(item)


# вывод 5 слов, наиболее сходных к слову "больно", и степень сходства
# result = model.most_similar("больно_ADV")[:5]   # НАРЕЧИЕ
# print("5 наиболее сходных слов к слову \"больно\":")
# for item in result:
#     print(item)

# result = model.most_similar("нисколько_NUM")[:5]   # ЧИСЛИТЕЛЬНОЕ
# print("5 наиболее сходных слов к слову \"нисколечко\":")
# for item in result:
#     print(item)

# result = model.most_similar("никто_PRON")[:5]   # местоимение
# print("5 наиболее сходных слов к слову \"нисколечко\":")
# for item in result:
#     print(item)

# result = model.most_similar("представить_VERB")[:5]
# print("5 наиболее сходных слов к слову \"делать\":")
# for item in result:
#     print(item)

text1 = proc_text("Проблема автоматической обработки текСтов")
text2 = proc_text("в тексте представлена проблема самосознания личности")

# print(text1)
# print(text2)
print(f"Оценка сходства предложений: {model.n_similarity(text1, text2)}")

