using UnityEngine;

public class CatHand:MonoBehaviour
{
    public float speed = 2f; // �ړ����x
    public float resetYPosition = -6f; // �����ʒu��Y���W�i��ʊO�����j
    public float startYPosition = 6f;  // �I����ɖ߂�Y���W�i��ʊO�㑤�j

    private Vector2 direction = Vector2.up; // �ړ������i�f�t�H���g�͏�����j
    private bool isMovingDown = false; // �������ɓ����Ă��邩�̃t���O

    void Update()
    {
        // ���݂̕����Ɉړ�
        transform.Translate(direction * speed * Time.deltaTime);

        // ������̈ړ����ɉ�ʊO�i��j�ɏo���ꍇ�A�����ʒu�Ƀ��Z�b�g
        if (!isMovingDown && transform.position.y > startYPosition)
        {
            ResetPosition();
        }

        // �������̈ړ����ɉ�ʊO�i���j�ɏo���ꍇ�A�����ʒu�Ƀ��Z�b�g
        if (isMovingDown && transform.position.y < resetYPosition)
        {
            ResetPosition();
        }
    }

    private void ResetPosition()
    {
        // �����_����X���W�ŏ��������A������̈ړ��ɖ߂�
        float randomX = Random.Range(-8.0f, 8.0f); // ��ʓ���X���W�͈͂�ݒ�
        transform.position = new Vector2(randomX, resetYPosition);
        direction = Vector2.up; // ������Ƀ��Z�b�g
        isMovingDown = false;  // �������t���O������
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Bubble�^�O�����I�u�W�F�N�g�ɐG�ꂽ�ꍇ
        if (other.CompareTag("Bubble"))
        {
            // �������Ɉړ���؂�ւ���
            direction = Vector2.down;
            isMovingDown = true;
        }
    }








}
