from natasha import (
    Segmenter,
    NewsEmbedding,
    NewsMorphTagger,
    NewsSyntaxParser,
    Doc)
import pymorphy2 as pm


def norm(txt):
    _, x = map(int, txt.split('_'))
    return x


def sent_to_dicts(sent):
    '''
    Преобразование предложения (формат CoNLL) в словари:
    1) словарь words - слова (ключ - id, значение - слово);
    2) словарь tree - дерево (ключ - id родителя, значение - список id сыновей).
    '''
    words = dict()
    for token in sent.tokens:
        if token.pos != 'PUNCT':
            norm_id = norm(token.id)
            words[norm_id] = token.text
            if token.rel == 'root':
                root = norm_id
    tree = {0: []}
    for k in words.keys():
        tree[k] = []
    for token in sent.tokens:
        if token.pos != 'PUNCT':
            norm_id = norm(token.id)
            norm_head_id = norm(token.head_id)
            tree[norm_head_id].append(norm_id)
    return words, root, tree


def normal_form(word):
    m = pm.MorphAnalyzer()
    return m.parse(word)[0].normal_form


def dicts_to_rpn(words, root, tree):
    '''
    Преобразование словарей в ОПЗ (с помощью нерекурсивного DFS).
    Список rpn - ОПЗ.
    '''
    if len(words) <= 1:
        return list(words.values())
    rpn = []
    stack = [(0, root)]
    colors = {k: 0 for k in words.keys()}
    while len(stack) > 0:
        pred, curr = stack[len(stack) - 1]
        if colors[curr] == 0:
            colors[curr] = 1
        elif colors[curr] == 1:
            if len(tree[curr]) > 1:
                rpn.extend(['*', len(tree[curr])])
            if curr != root:
                if len(tree[curr]) == 0:
                    rpn.extend([words[curr], words[pred], '*'])
                elif len(tree[curr]) > 0:
                    rpn.extend([words[pred], '*'])
            stack.pop()
        for nxt in reversed(tree[curr]):
            if colors[nxt] == 0:
                stack.append((curr, nxt))
    return rpn


def semantic_scheme(rpn):
    '''
    Преобразование ОПЗ в семантическую схему.
    Список ss - схемантическая схема.
    '''
    if len(rpn) <= 1:
        return rpn
    ss = []
    i = 0
    stack = []
    while i < len(rpn):
        if rpn[i] == '*':
            if i + 1 < len(rpn) and isinstance(rpn[i + 1], int):
                n = rpn[i + 1]
                m = 2
                rpn[i + 1] = str(rpn[i + 1])
            else:
                n = 2
                m = 1
            r = ' '.join(rpn[i - n:i + m])
            rpn[i - n:i + m] = [r]
            ss.append(r)
            i -= n
        i += 1
    return ss


def sent_to_ss(sent):
    '''
    Преобразование предложения (формат CoNLL) в сем. сх.
    '''
    words, root, tree = sent_to_dicts(sent)
    for k in words.keys():
        words[k] = normal_form(words[k])
    rpn = dicts_to_rpn(words, root, tree)
    ss = semantic_scheme(rpn)
    return ss


def compare(ss_q, ss_t):
    '''
    Сравнение сем. сх.
    cprox - семантическая близость.
    '''
    ss_q = set(ss_q)
    ss_t = set(ss_t)
    p = len(ss_q & ss_t)
    #print(f"intercsect len = {p}")
    m = len(ss_q)
    #print(f"исходный len = {m}")
    cprox = p / m
    return cprox


segmenter = Segmenter()
emb = NewsEmbedding()
morph_tagger = NewsMorphTagger(emb)
syntax_parser = NewsSyntaxParser(emb)

q = 'проблема автоматической обработки текстов'
doc = Doc(q)
doc.segment(segmenter)
doc.tag_morph(morph_tagger)
doc.parse_syntax(syntax_parser)
sent = doc.sents[0]
ss_q = sent_to_ss(sent)

t = 'проблема автоматической обработки изображений иногда решается с использованием нейронных сетей'
doc = Doc(t)
doc.segment(segmenter)
doc.tag_morph(morph_tagger)
doc.parse_syntax(syntax_parser)
sent = doc.sents[0]
ss_t = sent_to_ss(sent)

cprox = compare(ss_q, ss_t)

print('q = {:s}'.format(q))
print('t = {:s}'.format(t))
#print(f"ss_q (len - {len(ss_q)}) = {ss_q}")
#print(f"ss_t (len - {len(ss_t)}) = {ss_t}")
print('Семантическая близость = {:.0%}'.format(cprox))
